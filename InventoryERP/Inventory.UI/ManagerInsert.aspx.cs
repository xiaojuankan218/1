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
    public partial class ManagerInsert : System.Web.UI.Page
    {
        private readonly ManagerBLL managerBLL = new ManagerBLL();
        private readonly StoreBLL storeBLL = new StoreBLL();
        public DataTable STable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取所有仓库列表
            DataTable storeTable = storeBLL.GetAllStore();
            stno.DataSource = storeTable;
            stno.DataTextField = "stno";
            stno.DataValueField = "stno";
            stno.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            manager man = new manager();
            man.mno = txtmno.Value;
            man.mname = mname.Value;
            man.sex = ddlsex.SelectedValue;
            man.birthday = Convert.ToDateTime(birthday.Value);
            man.stno = stno.SelectedValue;
            if (managerBLL.Insert(man) > 0)
            {
                Response.Write("<script>alert('添加成功！');window.location.href='ManagerList.aspx';</script>");
                //Response.Redirect("ManagerList.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }
        }
    }
}