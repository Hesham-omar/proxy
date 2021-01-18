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

        public static string PostApi(string ApiUrl, request postData) {
           
            
            var client = new HttpClient();
            
            string endpoint = ApiUrl,result="";
            //var response = " && "+client.PostAsJsonAsync(endpoint, postData).GetAwaiter()
            //    .GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult() + "(" + postData.id + ")";
            var response =client.PostAsJsonAsync(endpoint, postData);
                 result=  " && " +  response.Result.Content.ReadAsStringAsync().Result + "(" + postData.id + ")";


            return result;
        }

    }
}