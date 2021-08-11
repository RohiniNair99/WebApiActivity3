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
    public class CourseController : ApiController
    {
        CourseBL blObj;

        [HttpPost]
        [ActionName("InsertCourse")]
        public HttpResponseMessage AddCourse(CourseDTO course)
        {
            try
            {
                if(course.CourseId ==null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Course null");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                blObj = new CourseBL();
                int result = blObj.AddCourse(course);
                if (result==1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Course Inserted Successfully");
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }

                else if(result==-1)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("CourseId already present.Try different CourseId");
                    return response;
                }
                else if(result==-2)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Course Title already taken.Try different Course Title.");
                    return response;
                }
                else if(result==-3)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Please input all values(CourseId/CourseTitle/CourseDuration/CourseMode)");
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
