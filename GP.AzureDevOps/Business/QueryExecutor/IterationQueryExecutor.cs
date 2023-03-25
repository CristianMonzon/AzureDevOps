// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace GP.AzureDevOps.Business.Query
{

    public class IterationQueryExecutor : BaseQueryExecutor
    {

        /// <summary>
        ///     Execute a WIQL (Work Item Query Language) query to return a list of work Items.
        /// </summary>
        /// <param name="project">The name of your project within your organization.</param>
        /// <returns>A list of <see cref="WorkItem"/> objects representing all the open bugs.</returns>
        public async Task<IList<WorkItem>> AllWorkItems(string project)
        {
            var credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);

            var wiql = new Wiql()
            {
                // NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
                Query = "Select [Id] " +
                        "From WorkItems " +
                        "WHERE [System.TeamProject] = '" + project + "' "
                        //"Where [Work Item Type] = 'Bug' " +        
                        //"And [System.State] <> 'Closed' Order By [State] Asc, [Changed Date] Desc",
            };

            return await WorkItemsAsync(credentials, wiql);
        }
        
        /// <summary>
        ///     Execute a WIQL (Work Item Query Language) query to return a list of Issue.
        /// </summary>
        /// <param name="project">The name of your project within your organization.</param>
        /// <returns>A list of <see cref="WorkItem"/> objects representing all the open bugs.</returns>
        public async Task<IList<WorkItem>> IssueWorkItems(string project)
        {
            var credentials = new VssBasicCredential(string.Empty, PersonalAccessToken);

            var wiql = new Wiql()
            {
                // NOTE: Even if other columns are specified, only the ID & URL are available in the WorkItemReference
                Query = "Select [Id] " +
                        "From WorkItems Where " +
                        "[Work Item Type] = 'Issue' " +
                        "AND [System.TeamProject] = '" + project + "' " 
            };

            return await WorkItemsAsync(credentials, wiql);
        }
    }
}