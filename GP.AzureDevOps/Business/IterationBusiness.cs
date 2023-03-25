// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using System.Threading.Tasks;
using GP.AzureDevOps.Business.Util;
using GP.AzureDevOps.Data;
using GP.AzureDevOps.Data.Json.Iteration;

namespace GP.AzureDevOps.Business
{
    public class IterationBusiness : BaseBusiness
    {
        private List<BIteration> ListBIteration { get; set; }
        
        public IterationBusiness()
        {
            ListBIteration = new List<BIteration>();
        }

        /// <summary>
        /// Gets the work items.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BIteration>> GetIterations(string projectName)
        {
            var url =$"{Config.OrganizationUrl}/{projectName}/_apis/work/teamsettings/iterations?api-version{Config.ApiVersion}";

            var objectJson = AzureJsonConverter.DownloadSerialized<JsonIteration>(url);

            List<JsonIteration> listBIteration = new List<JsonIteration>();
           
            foreach (var item in objectJson.value)
            {
                var bIteration = new BIteration(item);

                
                ListBIteration.Add(bIteration);
            }
            return ListBIteration;
        }
    }
}
