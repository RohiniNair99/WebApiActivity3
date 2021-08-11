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
    public class FacultyController : ApiController
    {

        FacultyBL blObj;

        [HttpPost]
        [ActionName("InsertFaculty")]
        public HttpResponseMessage AddCourse(FacultyDTO faculty)
        {
            try
            {
                
                blObj = new FacultyBL();
                int result = blObj.AddFaculty(faculty);
                if (result == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Faculty Inserted Successfully");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if (result == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("PSNO already present.Try different PSNO");
                    return response;
                }
                else if (result == -2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Faculty Name already taken.Try different Faculty Name.");
                    return response;
                }
                else if (result == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values(PSNO/EmailId/facultyName)");
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
