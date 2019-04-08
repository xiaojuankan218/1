using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.BLL;
using Inventory.Model;
using Inventory.UI;

namespace Inventory.UI
{
    public partial class GoodEdit : System.Web.UI.Page
    {
        private readonly GoodsBLL goodBLL = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string gno = Request.QueryString["gno"].ToString();
                    var good = goodBLL.GetSingleByno(gno);
                    txtgno.Value = good.gno;
                    gname.Value = good.gname;
                    price.Value = good.price.ToString();
                    producer.Value = good.producer;
                }
                catch (Exception)
                {
                    Response.Redirect("GoodList.aspx");

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var good = new goods();
            good.gno = txtgno.Value;
            good.gname = gname.Value;
            good.price = decimal.Parse(price.Value);
            good.producer = producer.Value;
            int number=goodBLL.Update(good);
            if (number > 0)
            {
                Response.Write("<script>alert('修改成功！');window.location.href='GoodList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }
        }
    }
}