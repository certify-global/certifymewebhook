using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CERTIFYWebHookAPI.Models;
using CERTIFYWebHookAPI.Utility;
using Newtonsoft.Json;

namespace CERTIFYWebHookAPI.Controllers
{
    public class ReportController : ApiController
    {


        /// <summary>
        /// Method to recieve data from CERTIFY.me
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post(Report data)
        {

            try
            {
                if (Request != null && Request.Headers.Contains("HMAC"))//Validate for HMAC Value recieved from the Certify.me Webhook
                {
                    var key = Request.Headers.GetValues("HMAC").First();
                    if (!new HMACUtil().VerifyHashedPassword(key, ConfigurationManager.AppSettings["HMACKey"]))//HMAC value is created based on the Key in the config , should match the one provided on the portal
                    {
                        return ReturnUnAuthorized();
                    }

                    //IF AUTHORIZED PROCESS DATA. 
                    //WRITE RECIEVED DATA TO A FILE.  
                    string time = DateTime.Now.ToString("yyyyMMddhhmmssff");
                    string path =
                        HttpContext.Current.Server.MapPath("~/App_Data/" + time + "post.txt");
                    File.WriteAllText(path, JsonConvert.SerializeObject(data));
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) //SEND STATUS 200 MESSAGE
                    {
                        Content = new StringContent("Data Received"),
                    };
                    return responseMessage;
                }
                else
                {
                    return ReturnUnAuthorized(); //ERROR 401
                }
            }
            catch (Exception ex)
            {
                //log your exception 
                return InternalServerError(); //ERROR 500

            }
        }

        private static HttpResponseMessage ReturnUnAuthorized()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Unauthorized"),
            };
            return responseMessage;
        }

        private static HttpResponseMessage InternalServerError()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("InternalServerError"),
            };
            return responseMessage;
        }
    }
}
