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
    public partial class ManagerEdit : System.Web.UI.Page
    {
        ManagerBLL managerBLL = new ManagerBLL();
        private readonly StoreBLL storeBLL = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable storeTable = storeBLL.GetAllStore();
                stno.DataTextField = "stno";
                stno.DataValueField = "stno";
                stno.DataSource = storeTable;
                stno.DataBind();
                try
                {
                    string mno = Request.QueryString["mno"].ToString();
                    var man = managerBLL.GetSingleByno(mno);
                    txtmno.Value = man.mno;
                    mname.Value = man.mname;
                    ddlsex.SelectedValue = man.sex;
                    birthday.Value = man.birthday.ToShortDateString();
                    stno.SelectedValue = man.stno;
                }
                catch (Exception)
                {
                    Response.Redirect("ManagerList.aspx");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var man = new manager();
            man.mno = txtmno.Value;
            man.mname = mname.Value;
            man.sex = ddlsex.SelectedValue;
            man.birthday =DateTime.Parse(birthday.Value);
            man.stno = stno.SelectedValue;
            int number = managerBLL.Update(man);
            if (number > 0)
            {
                Response.Write("<script>alert('修改成功！');window.location.href='ManagerList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }
        }
    }
}