// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using System.Threading.Tasks;
using GP.AzureDevOps.Business.Util;
using GP.AzureDevOps.Data;
using GP.AzureDevOps.Data.Json.Project;
using GP.AzureDevOps.Data;

namespace GP.AzureDevOps.Business
{
    public class ProjectBusiness : BaseBusiness
    {
        private List<BProject> ListBProject { get; set; }

        public ProjectBusiness()
        {
            ListBProject = new List<BProject>();
        }

        /// <summary>
        /// Gets the work items.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BProject>> GetProjects()
        {
            var url =$"{Config.OrganizationUrl}/_apis/projects?api-version{Config.ApiVersion}";

            var objectJson = AzureJsonConverter.DownloadSerialized<JsonProject>(url);

          
            foreach (var item in objectJson.value)
            {
                var bIteration = new BProject(item);
                ListBProject.Add(bIteration);
            }

            return ListBProject;
        }

        public IList<BIteration> GetIterations(string projectName)
        {
            IList<BIteration> iterationsList = new List<BIteration>() ;

            var iterationBusiness = new IterationBusiness();
            var iterationsTask = iterationBusiness.GetIterations(projectName);
            iterationsList = iterationsTask.Result;

            return iterationsList;
        }
    }
}
