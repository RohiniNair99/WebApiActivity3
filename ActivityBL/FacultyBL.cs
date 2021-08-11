using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;
using Activity_DAL;

namespace ActivityBL
{
    public class FacultyBL
    {
        FacultyDAL dalObj;

        public FacultyBL()
        {
            dalObj = new FacultyDAL();

        }

        public int AddFaculty(FacultyDTO facObj)
        {
            try
            {

                int result = dalObj.AddFaculty(facObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
