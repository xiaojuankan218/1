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
    public partial class GoodInsert : System.Web.UI.Page
    {
        private readonly GoodsBLL good = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            
            goods good1 = new goods();
            good1.gno = Request.Form["gno"];
            good1.gname = Request.Form["gname"];
            good1.price =Convert.ToDecimal( Request.Form["price"]);
            good1.producer = Request.Form["producer"];
            if (good.Insert(good1) > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }

        }

        
    }
}