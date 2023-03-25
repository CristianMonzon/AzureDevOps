// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.AzureDevOps.Business.Query;
using GP.AzureDevOps.Business.Util;
using GP.AzureDevOps.Data;
using GP.AzureDevOps.Data.Json.WorkItem;
using GP.AzureDevOps.Data.Json.WorkItemIssue;

namespace GP.AzureDevOps.Business
{
    public class WorkItemBusiness : BaseBusiness
    {
        private List<BWorkItem> ListWorkItem { get; set; }

        public string ProjectName { get; set; }

        public string Iteration { get; set; }

        public WorkItemBusiness(string projectName, string iteration)
        {
            ProjectName = projectName;
            Iteration = iteration;
            ListWorkItem = new List<BWorkItem>();
        }

        /// <summary>
        /// Gets the work items.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BWorkItem>> GetWorkItems()
        {
            var qe = new WorkItemQueryExecutor();
            var workItems = await qe.AllWorkItems(ProjectName, Iteration).ConfigureAwait(false);

            foreach (var workItem in workItems)
            {
                var objectJsonWorkItem = AzureJsonConverter.DownloadSerialized<JsonWorkItem>(workItem.Url);
                ListWorkItem.Add(new BWorkItem(objectJsonWorkItem));
            }

            return ListWorkItem;
        }

        /// <summary>
        /// Gets the issue work items with childs
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BIssue>> GetIssueWithWorkItem()
        {
            List<BIssue> listBIssues = new List<BIssue>();

            var qe = new WorkItemQueryExecutor();
            var workItems = await qe.IssueWorkItems(ProjectName, Iteration).ConfigureAwait(false);

            foreach (var workItem in workItems)
            {
                var url = $"{Config.OrganizationUrl}/_apis/wit/workitems?ids={workItem.Id}&$expand=relations&api-version={Config.ApiVersion}";
                var objectJsonIssue = AzureJsonConverter.DownloadSerialized<JsonWorkItemIssue>(url);
                var newBIssue = new BIssue(objectJsonIssue);

                //Get list of childs
                if (newBIssue.FirstValue.relations!=null)
                    foreach (var chield in newBIssue.FirstValue.relations)
                    {
                        var chieldUrl = chield.url;
                        var objectWorkItem = AzureJsonConverter.DownloadSerialized<JsonWorkItem>(chieldUrl);
                        newBIssue.AddWorkItem(objectWorkItem);
                    }

                listBIssues.Add(newBIssue);
            }

            return listBIssues;
        }

        public async Task<IList<BWorkItem>> GetTasks()
        {
            if (ListWorkItem != null && !ListWorkItem.Any())
            {
                var result = GetWorkItems();
            }
            if (ListWorkItem == null) return ListWorkItem;
            return ListWorkItem.Where(c => c.IsTask).ToList();
        }

        public async Task<IList<BWorkItem>> GetIssue()
        {
            if (ListWorkItem != null && !ListWorkItem.Any())
            {
                var result = GetWorkItems();
            }
            if (ListWorkItem == null) return ListWorkItem;
            return ListWorkItem.Where(c => c.IsIssue).ToList();
        }

        public async Task<IList<BWorkItem>> GetEpic()
        {
            if (ListWorkItem != null && !ListWorkItem.Any())
            {
                var result = GetWorkItems();
            }
            if (ListWorkItem == null) return ListWorkItem;
            return ListWorkItem.Where(c => c.IsEpic).ToList();
        }
    }
}
