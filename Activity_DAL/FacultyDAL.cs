using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace Activity_DAL
{
    public class FacultyDAL
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public FacultyDAL()
        {
            sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public int AddFaculty(FacultyDTO facultyObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspFacultyAdd", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PSNO", facultyObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@EmailId", facultyObj.EmailId);
                sqlCmd.Parameters.AddWithValue("@FacultyName", facultyObj.FacultyName);

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
