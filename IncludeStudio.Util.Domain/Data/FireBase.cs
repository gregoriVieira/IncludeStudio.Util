using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace IncludeStudio.Util.Domain.Data
{
    public static class FireBase
    {
        public static string BaseUrl { get; set; }
        public static  string AuthKey { get; set; }
        public static string JsonPath { get; set; }

        public static void InsertData(object data)
        {
            if (data == null)
                throw new Exception("data cannot be null");

            try
            {      
                var json = JsonConvert.SerializeObject(data);

                var url = $"{BaseUrl}/{JsonPath}?auth={AuthKey}";
                HttpWebRequest request = WebRequest.CreateHttp(url);

                request.Method = "POST";
                request.ContentType = "application/json";
                var bytes = Encoding.UTF8.GetBytes(json);
                request.ContentLength = bytes.Length;
                request.GetRequestStream().Write(bytes, 0,bytes.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
