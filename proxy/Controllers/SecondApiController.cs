using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using proxy.Models;

namespace proxy.Controllers {
    public class SecondApiController : ApiController {

        proxyftEntities db = new proxyftEntities();

        public string Post(request data) {
            try {
                if (data.id == 2 || data.id == 3) {

                    db.request.Add(data);
                    db.SaveChanges();

                    return "Second API called successfully";
                    
                } 
                else
                    return "wrong api";
            } 
            catch (Exception e) {
                return "somthing went wrong from second api";
            }
        }

    }
}