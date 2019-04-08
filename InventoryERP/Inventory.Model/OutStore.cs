using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    public partial class OutStore
    {
        //outID, gno, stno, number, outTime
        public string outID { get; set; }
        public string gno { get; set; }

        public string stno { get; set; }
        public string mno { get; set; }
        public int number { get; set; }

        public DateTime outTime { get; set; }
    }
}
