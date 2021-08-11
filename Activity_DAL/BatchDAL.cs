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
    public class BatchDAL
    {
        SqlConnection sqlCon;
        SqlCommand sqlCmd;

        public BatchDAL()
        {
            sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        }

        public int AddBatch(BatchDTO batch)
        {
            try
            {
                sqlCmd = new SqlCommand("uspBatchInput", sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@batchName", batch.BatchName);
                sqlCmd.Parameters.AddWithValue("@StartDate", batch.StartDate);
                sqlCmd.Parameters.AddWithValue("@StudentCount", batch.StudentCount);
                sqlCmd.Parameters.AddWithValue("ModelId", batch.ModelId);
                

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
