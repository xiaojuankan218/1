using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 库存总量
    /// </summary>
    [Serializable]
   public class inventSum
    {
        /// <summary>
        /// 库位编号
        /// </summary>
        public  string stno { get; set; }
        /// <summary>
        /// 总库存重量
        /// </summary>
        public  int s_invent { get; set; }
    }
}
