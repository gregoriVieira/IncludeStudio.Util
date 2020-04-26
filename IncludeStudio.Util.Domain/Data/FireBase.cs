using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace IncludeStudio.Util.Domain.Data
{
    public class FireBase
    {
        private string baseUrl { get; set; }
        private string authKey { get; set; }
        private string jsonPath { get; set; }
        public FireBase()
        {
            baseUrl = string.Empty;
            authKey = string.Empty;
            jsonPath = string.Empty;
        }

        public void InsertData(object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);

                HttpWebRequest request = WebRequest.CreateHttp($"{baseUrl}/{jsonPath}?auth{authKey}");

                request.Method = "POST";
                request.ContentType = "application/json";
                var bytes = Encoding.UTF8.GetBytes(json);
                request.ContentLength = bytes.Length;
                request.GetRequestStream().Write(bytes, 0,bytes.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
            catch (Exception)
            {
                
            }
        }
    }
}
