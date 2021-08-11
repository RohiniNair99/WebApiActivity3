using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace Activity_DAL
{
    public class CourseFacultyMap_DAL
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public CourseFacultyMap_DAL()
        {
            sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public int AddCourseFacultyMap(CourseFacultyMap_DTO cfmObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspMapFacultyCourse", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CourseId", cfmObj.CourseId);
                sqlCmd.Parameters.AddWithValue("@PSNO", cfmObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@PrimaryFaculty", cfmObj.PrimaryFaculty);

                sqlCon.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmd.Parameters.Add(prmReturn);
                sqlCmd.ExecuteNonQuery();
                int returnVal = Convert.ToInt32(prmReturn.Value);
                return returnVal;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
