using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity_DAL;
using ActivityDTO;

namespace ActivityBL
{
    public class CourseBL
    {
        CourseDAL dalObj;
        
        public CourseBL()
        {
            dalObj = new CourseDAL();
            
        }

        public int AddCourse(CourseDTO courseObj)
        {
            try
            {
                
                int result = dalObj.AddCourse(courseObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
