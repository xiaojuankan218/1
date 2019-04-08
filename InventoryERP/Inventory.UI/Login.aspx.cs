using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;

namespace Inventory.UI
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ManagerBLL managerBLL = new ManagerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string mno = Request.Form["mno"].ToString();
            string mname = Request.Form["mname"].ToString();
            if (managerBLL.Login(mno,mname))
            {
                Session["mno"] = mno;
                Response.Cookies["mname"].Value = mname;
                Response.Cookies["mname"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}