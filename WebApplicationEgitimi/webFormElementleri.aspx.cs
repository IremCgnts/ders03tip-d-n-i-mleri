using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationEgitimi
{
    public partial class webFormElementleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = " butona tıklandı";
            Label1.Text = "Dropdownlistten seçilen değer:" +
                DropDownList1.SelectedValue + "- SelectedItem.Text:" +
                 DropDownList1.SelectedItem.Text;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "HiddenField elementi sayfada gizli veri tutar";
        }
    }
}