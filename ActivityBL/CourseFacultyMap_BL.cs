using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;
using Activity_DAL;

namespace ActivityBL
{
    public class CourseFacultyMap_BL
    {
        CourseFacultyMap_DAL dalObj;

        public CourseFacultyMap_BL()
        {
            dalObj = new CourseFacultyMap_DAL();

        }

        public int AddCourseFacultyMap(CourseFacultyMap_DTO obj)
        {
            try
            {

                int result = dalObj.AddCourseFacultyMap(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
