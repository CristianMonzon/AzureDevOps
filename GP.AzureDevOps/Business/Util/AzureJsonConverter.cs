// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using GP.AzureDevOps.Business.Configuration;

namespace GP.AzureDevOps.Business.Util
{
    public static class AzureJsonConverter
    {
        private static AzureConfig Config = new AzureConfig();

        /// <summary>
        /// Downloads the serialized.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static T DownloadSerialized<T>(string url) where T : new()
        {

            using (var request = new WebClient())
            {

                string jsonData = string.Empty;
                try
                {
                    SetHeader(request);

                    jsonData = request.DownloadString(url);
                }
                catch (Exception ex)
                {
                }
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
            }

        }

        /// <summary>
        /// Downloads the j son result.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string DownloadJSonResult(string url)
        {
            string jsonData;
            using (var request = new WebClient())
            {
                try
                {
                    SetHeader(request);

                    jsonData = request.DownloadString(url);
                }
                catch (Exception ex)
                {
                    jsonData = ex.Message;
                }
            }
            return jsonData;
        }

        private static void SetHeader(WebClient request)
        {
            var username = "";
            var password = Config.PersonalAccessToken;
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);
        }
    }
}

