using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;
using System.Data;
using Inventory.Model;

namespace Inventory.UI
{
   
    public partial class GoodList : System.Web.UI.Page
    {
        public GoodsBLL goodsBLL = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = goodsBLL.GetAllGood();
            Repeater1.DataSource=dt;
            Repeater1.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton) sender;
            var gno= link.CommandArgument.ToString();

            var good = new goods();
            int number = goodsBLL.Delete(gno);
            if (number > 0)
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Response.Redirect("GoodList.aspx");
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }
            

          


        }
    }
}