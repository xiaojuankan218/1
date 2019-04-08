using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;
using Inventory.Model;

namespace Inventory.UI
{
    public partial class StoreList : System.Web.UI.Page
    {
        private readonly StoreBLL storeBLL = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = storeBLL.GetAllStore();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            var mno = link.CommandArgument.ToString();

            int number = storeBLL.Delete(mno);
            if (number > 0)
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Response.Redirect("StoreList.aspx");
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }
        }
    }
}