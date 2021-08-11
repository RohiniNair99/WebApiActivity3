using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity_DAL;
using ActivityDTO;

namespace ActivityBL
{
    public class BatchBL
    {
        BatchDAL dalObj;

        public BatchBL()
        {
            dalObj = new BatchDAL();

        }

        public int AddBatch(BatchDTO batch)
        {
            try
            {

                int result = dalObj.AddBatch(batch);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
