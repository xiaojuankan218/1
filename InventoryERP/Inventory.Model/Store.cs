using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 仓库
    /// </summary>
    [Serializable]
    public class Store
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string stno { get; set; }
        /// <summary>
        /// 仓库位置
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 仓库联系电话
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 仓库容量
        /// </summary>
        public int capacity { get; set; }
    }
}
