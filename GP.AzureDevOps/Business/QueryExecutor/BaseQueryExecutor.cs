// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.AzureDevOps.Business.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace GP.AzureDevOps.Business.Query
{
    public abstract class BaseQueryExecutor
    {
        private AzureConfig Config = new AzureConfig();

        protected readonly Uri Uri;
        protected readonly string PersonalAccessToken;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItemQueryExecutor" /> class.
        /// </summary>
        /// <param name="orgName">
        ///     An organization in Azure DevOps Services. If you don't have one, you can create one for free:
        ///     <see href="https://go.microsoft.com/fwlink/?LinkId=307137" />.
        /// </param>
        /// <param name="personalAccessToken">
        ///     A Personal Access Token, find out how to create one:
        ///     <see href="/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops" />.
        /// </param>
        private BaseQueryExecutor(string orgName, string personalAccessToken)
        {

            this.Uri = new Uri("https://dev.azure.com/" + orgName);
            this.PersonalAccessToken = personalAccessToken;
        }

        public BaseQueryExecutor() 
        {
            this.Uri = new Uri(Config.OrganizationUrl);
            this.PersonalAccessToken = Config.PersonalAccessToken;
        }

        protected async Task<IList<WorkItem>> WorkItemsAsync(VssBasicCredential credentials, Wiql wiql)
        {
            // create instance of work item tracking http client
            using (var httpClient = new WorkItemTrackingHttpClient(this.Uri, credentials))
            {
                // execute the query to get the list of work items in the results
                var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                var ids = result.WorkItems.Select(item => item.Id).ToArray();

                // some error handling
                if (ids.Length == 0)
                {
                    return Array.Empty<WorkItem>();
                }

                // build a list of the fields we want to see
                //var fields = new[] { "System.Id", "System.Title", "System.State", "System.WorkItemType", "System.CreatedDate", "System.AssignedTo" };
                var fields = new[] {"System.Id"};

                // get work items for the ids found in query
                return await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);
            }
        }
    }
}
