using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityDTO
{
    public class BatchDTO
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public System.DateTime StartDate { get; set; }
        public int StudentCount { get; set; }
        public int ModelId { get; set; }
    }
}
