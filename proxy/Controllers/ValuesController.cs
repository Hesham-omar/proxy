using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using proxy.Models;

namespace proxy.Controllers {
    public class ValuesController : ApiController {

        string[] urls = { "http://192.168.8.102:44/api/FirstApi", "http://192.168.8.102:44/api/secondApi" };
        

        public string Get(request data) {
            string result="";
            int count = 0;

            try {
                switch (data.id) {

                    case 1:
                        return ApiCall.PostApi(urls[0],data);

                    case 2:
                        return ApiCall.PostApi(urls[1], data);

                    case 3:
                        
                            Parallel.ForEach(urls, url => {
                                count++;
                                lock (result) { 
                                    result += ApiCall.PostApi(url, data);
                                }
                                
                            });

                        return result;

                    default:
                        return "wrong data";

                }
            } catch (Exception e){
                return "something went wrong"+e.ToString();

            }
        }

    }
}
