using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;
using Inventory.Model;
using System.Data;

namespace Inventory.UI
{
  
    public partial class ManagerList : System.Web.UI.Page
    {
        private readonly ManagerBLL managerBLL = new ManagerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = managerBLL.GetAllManager();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton) sender;
            var mno = link.CommandArgument.ToString();

            int number = managerBLL.Delete(mno);
            if (number > 0)
            {
                Response.Write("<script>alert('删除成功！');window.location.href='ManagerList.aspx';</script>");
                //Response.Redirect("ManagerList.aspx");
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }
        }
    }
}