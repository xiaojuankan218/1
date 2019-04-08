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
    public partial class IntoStoreList : System.Web.UI.Page
    {
        public IntoStoreBLL intoStoreBLL = new IntoStoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = intoStoreBLL.GetAllIntoStore();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}