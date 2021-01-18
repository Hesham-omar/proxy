using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace proxy.Models {
    public class ApiCall {

        public static string GetApi(string ApiUrl) {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            
            using (var response1 = request.GetResponse()) {
                using (var reader = new StreamReader(response1.GetResponseStream())) {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;

        }

        public static string PostApi(string ApiUrl, request postData) {
           

            var client = new HttpClient();
            string endpoint = ApiUrl;
            var response = " && "+client.PostAsJsonAsync(endpoint, postData).GetAwaiter()
                .GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult() + "(" + postData.id + ")";

            return response;
        }

    }
}