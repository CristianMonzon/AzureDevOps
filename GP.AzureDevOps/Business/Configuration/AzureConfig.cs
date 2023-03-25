// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

namespace GP.AzureDevOps.Business.Configuration
{
    public class AzureConfig
    {
        /// <summary>
        /// The azure dev ops personalAcessToken
        /// </summary>
        public string PersonalAccessToken =
            System.Configuration.ConfigurationManager.AppSettings["Config.AzureDevOpsPersonalAccessToken"];

        /// <summary>
        /// The azure dev ops organization
        /// </summary>
        public string Organization = System.Configuration.ConfigurationManager.AppSettings["Config.AzureDevOpsOrganization"];

        /// <summary>
        /// The azure dev ops organization URL
        /// Change to the URL of your Azure DevOps account; NOTE: This must use HTTPS
        /// </summary>
        public string OrganizationUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Config.AzureDevUrl"] + "/" + Organization;
            }
        }

        /// <summary>
        /// The azure API version
        /// </summary>
        public string ApiVersion = System.Configuration.ConfigurationManager.AppSettings["Config.AzureApiVersion"];

        /// <summary>
        /// The project name
        /// </summary>
        public string ProjectName = System.Configuration.ConfigurationManager.AppSettings["Config.ProjectPanel"];

        /// <summary>
        /// The iteration name
        /// </summary>
        public string IterationName = System.Configuration.ConfigurationManager.AppSettings["Config.IterationName"];
    }
}
