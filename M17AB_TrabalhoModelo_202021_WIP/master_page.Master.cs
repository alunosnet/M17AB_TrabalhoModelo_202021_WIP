using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP
{
    public partial class master_page : System.Web.UI.MasterPage
    {
        //ocorre antes do page_load, incluindo o page_load das páginas
        protected void Page_Init(object sender,EventArgs e)
        {
            //Console.Write("qualquer coisa");
        }
        //ocorre depois do page_load das páginas
        protected void Page_Load(object sender, EventArgs e)
        {
            //testar se o cookie existe
            HttpCookie cookie = Request.Cookies["M17ABaviso"];
            if (cookie != null)
                div_aviso.Visible = false;
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            //criar o cookie e enviar para o browser
            div_aviso.Visible = false;
            HttpCookie novo = new HttpCookie("M17ABaviso");
            novo.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(novo);
        }
    }
}