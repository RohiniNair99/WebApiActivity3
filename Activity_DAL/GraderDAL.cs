using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityDTO;

namespace Activity_DAL
{
    public class GraderDAL
    {

        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public GraderDAL()
        {
            sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public int AddGrade(GraderDTO graderObj)
        {
            try
            {
                sqlCmd = new SqlCommand("uspGraderInput", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BCFId", graderObj.BCFId);
                sqlCmd.Parameters.AddWithValue("@PSNO", graderObj.PSNO);
                sqlCmd.Parameters.AddWithValue("@Score", graderObj.Score);

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
