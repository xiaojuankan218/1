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
    public partial class IntoStore : System.Web.UI.Page
    {
        private readonly IntoStoreBLL intoStoreBLL = new IntoStoreBLL();
        private readonly InventBLL inventBLL = new InventBLL();
        private readonly StoreBLL storeBLL = new StoreBLL();
        private readonly GoodsBLL goodsBLL = new GoodsBLL();
        public DataTable STable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取列表
            DataTable inventTable = inventBLL.GetAllInvent();
            gno.DataSource = inventTable;
            gno.DataTextField = "gno";
            gno.DataValueField = "gno";
            gno.DataBind();
            stno.DataSource = inventTable;
            stno.DataTextField = "stno";
            stno.DataValueField = "stno";
            stno.DataBind();
        }

        /// <summary>
        /// 添加入库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            Model.IntoStore intostore = new Model.IntoStore();
            intostore.gno = this.gno.SelectedValue;
            intostore.stno = this.stno.SelectedValue;
            intostore.number = Convert.ToInt32(txtNumber.Text.Trim());
            DateTime nowTime = DateTime.Now;
            intostore.intoTime = nowTime;
            intostore.mno = Session["mno"].ToString();
            if (intoStoreBLL.Insert(intostore) > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
                //Response.Redirect("StoreList.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }
            Response.Redirect("IntoStoreList.aspx");
        }

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}