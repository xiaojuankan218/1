using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 仓库管理员
    /// </summary>
    [Serializable]
   public class manager
    {
        /// <summary>
        /// 管理员编号
        /// </summary>
        public  string mno { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public  string mname { get; set; }
        /// <summary>
        /// 管理员性别
        /// </summary>
        public  string sex { get; set; }
        /// <summary>
        /// 管理员生日
        /// </summary>
        public DateTime birthday { get; set;}
        /// <summary>
        /// 管理仓库号
        /// </summary>
        public  string stno { get; set; }
    }
}
