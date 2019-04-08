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
    public partial class StoreInsert : System.Web.UI.Page
    {
        private readonly StoreBLL storeBLL = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Store store= new Store();
            store.stno = txtstno.Value;
            store.address= address.Value;
            store.telephone = telephone.Value;
            store.capacity = Convert.ToInt32(capacity.Value);
            if (storeBLL.Insert(store) > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
                //Response.Redirect("StoreList.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }
            Response.Redirect("StoreList.aspx");
        }
    }
}