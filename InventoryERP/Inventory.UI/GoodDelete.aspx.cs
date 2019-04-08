using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;
using Inventory.Model;
namespace Inventory.UI
{
    public partial class GoodDelete : System.Web.UI.Page
    {
        private readonly GoodsBLL good = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string gno = Request.Form["gno"];
            if (good.Delete(gno) > 0)
            {
                Response.Write("<script>alert('删除成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('不存在该商品编号，请确认后重新输入！')</script>");
            }
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {

        }
    }
}