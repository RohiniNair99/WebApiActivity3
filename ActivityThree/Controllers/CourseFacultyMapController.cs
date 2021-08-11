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
    public class CourseFacultyMapController : ApiController
    {

        CourseFacultyMap_BL blObj;

        [HttpPost]
        [ActionName("InsertFacultyCourseMap")]
        public HttpResponseMessage AddCourse(CourseFacultyMap_DTO obj)
        {
            try
            {

                blObj = new CourseFacultyMap_BL();
                int result = blObj.AddCourseFacultyMap(obj);
                if (result == 1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Faculty Course Mapping Inserted Successfully");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if (result == -1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("This data has already been entered.");
                    return response;
                }
                
                else if (result == -3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values(CourseId/PSNO/PrimaryFaculty)");
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
