using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace Activity_DAL
{
    public class CourseDAL
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public CourseDAL()
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public int AddCourse(CourseDTO courseObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspAddCourses", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CourseId", courseObj.CourseId);
                sqlCmd.Parameters.AddWithValue("@CourseTitle", courseObj.CourseTitle);
                sqlCmd.Parameters.AddWithValue("@CourseDuration", courseObj.CourseDuration);
                sqlCmd.Parameters.AddWithValue("CourseMode", courseObj.CourseMode);
                sqlCmd.Parameters.AddWithValue("@Curriculum", null);

                sqlCon.Open();

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.ParameterName = "ReturnValue";
                prmReturn.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmd.Parameters.Add(prmReturn);
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
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
