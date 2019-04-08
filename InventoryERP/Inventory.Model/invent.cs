using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 库存信息类
    /// </summary>
    [Serializable]
    public class invent
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public  string stno { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public  string gno { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public  int number { get; set; }
    }
}
