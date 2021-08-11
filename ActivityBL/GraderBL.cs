using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;
using Activity_DAL;


namespace ActivityBL
{
    public class GraderBL
    {
        GraderDAL dalObj;

        public GraderBL()
        {
            dalObj = new GraderDAL();

        }

        public int AddGrade(GraderDTO graderObj)
        {
            try
            {

                int result = dalObj.AddGrade(graderObj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
