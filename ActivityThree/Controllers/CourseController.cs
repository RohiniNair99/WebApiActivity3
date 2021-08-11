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
                if (course.CourseId != null && course.CourseTitle != null && course.CourseDuration != 0 && course.CourseMode != null)
                {

                    blObj = new CourseBL();
                    int result = blObj.AddCourse(course);
                    if (result == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Course Inserted Successfully. \nReturn Value: "+result);
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        return response;
                    }

                    else if (result == -1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("CourseId already present.Try different CourseId. \nReturn Value: "+result);
                        return response;
                    }
                    else if (result == -2)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Course Title already taken.Try different Course Title.\nReturn Value:"+result);
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent(result.ToString());
                        return response;
                    }
                }
                else 
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    int result = -3;
                    response.Content = new StringContent("Please input all values(CourseId/CourseTitle/CourseDuration/CourseMode) \nReturn Value: "+result);
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
