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
    public partial class StoreEdit : System.Web.UI.Page
    {
        private readonly StoreBLL storeBLL = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                try
                {
                    string stno = Request.QueryString["stno"].ToString();
                    var store = storeBLL.GetSingleByno(stno);
                    txtstno.Value = store.stno;
                    address.Value = store.address;
                    telephone.Value = store.telephone;
                    capacity.Value = store.capacity.ToString();

                }
                catch
                {
                    Response.Redirect("StoreList.aspx");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var store = new Store();
            store.stno = txtstno.Value;
            store.address = address.Value;
            store.telephone = telephone.Value;
            store.capacity = Int32.Parse(capacity.Value);
            int number = storeBLL.Update(store);
            if (number>0)
            {
                Response.Write("<script>alert('修改成功！');window.location.href='StoreList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }

        }
    }
}