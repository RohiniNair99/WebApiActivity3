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
                if (grader.BCFId != 0 && grader.PSNO != 0 && grader.Score != 0)
                {
                    blObj = new GraderBL();
                    int result = blObj.AddGrade(grader);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Grade Inserted Successfully.\nReturn Value: " + result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("This data has been already entered. \nReturn Value:" + result);
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Return Value:" + result);
                        return response;
                    }
                }

                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    int result = -3;
                    response.Content = new StringContent("Please input all values(BCFId/PSNO/Score). \nReturn Value: " + result);
                    return response;
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
