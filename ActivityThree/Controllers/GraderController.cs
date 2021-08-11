using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActivityBL;
using ActivityDTO;
using Newtonsoft.Json;

namespace ActivityThree.Controllers
{
    public class GraderController : ApiController
    {
        GraderBL blObj;

        [HttpPost]
        [ActionName("InsertGrade")]
        public HttpResponseMessage AddGrade(GraderDTO grader)
        {
            try
            {
                
                blObj = new GraderBL();
                int result = blObj.AddGrade(grader);
                if (result == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Grade Inserted Successfully");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if (result == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("This data has been already entered.");
                    return response;
                }
                
                else if (result == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values(BCFId/PSNO/Score)");
                    return response;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject("Something went wrong"));
                return response;
            }
        }
    }
}
