// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Threading.Tasks;
using GP.AzureDevOps.Business.Util;
using Newtonsoft.Json;

namespace GP.AzureDevOps.Business
{
    public class ApiBusiness
    {
        public string ProjectName { get; set; }

        public ApiBusiness(string projectName)
        {
            ProjectName = projectName;
        }

        /// <summary>
        /// Gets the query in json.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static async Task<string> GetQueryInJson(string url)
        {
            var jSonResult = AzureJsonConverter.DownloadJSonResult(url);
            return FormatJson(jSonResult);

        }

        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

    }
}
