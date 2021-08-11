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

                blObj = new BatchBL();
                int result = blObj.AddBatch(batch);
                if (result == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Batch Inserted Successfully");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if (result == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Batch Name already present.Try different Batch Name");
                    return response;
                }
                else if (result == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("ModelId already taken.Try different Model Id.");
                    return response;
                }
                else if (result == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values(BatchName/StartDate/StudentCount/ModelId");
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
