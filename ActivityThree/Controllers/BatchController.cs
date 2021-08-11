using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActivityDTO;
using ActivityBL;
using Newtonsoft.Json;

namespace ActivityThree.Controllers
{
    public class BatchController : ApiController
    {

        BatchBL blObj;

        [HttpPost]
        [ActionName("InsertBatch")]
        public HttpResponseMessage AddBatch(BatchDTO batch)
        {
            try
            {
                if (batch.BatchName != null && batch.ModelId != 0 && batch.StartDate != null && batch.StudentCount != 0)
                {

                    blObj = new BatchBL();
                    int result = blObj.AddBatch(batch);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Batch Inserted Successfully. \nReturn Value:"+result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Batch Name already present.Try different Batch Name. \nReturn Value:"+result);
                        return response;
                    }
                    else if (result == -2)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("ModelId already taken.Try different Model Id. \nRetur Value"+result);
                        return response;
                    }
                    else 
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Return Value"+result.ToString());
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    int result = -3;
                    response.Content = new StringContent("Please input all values(BatchName/StartDate/StudentCount/ModelId. \nReturn Value:"+result);
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
