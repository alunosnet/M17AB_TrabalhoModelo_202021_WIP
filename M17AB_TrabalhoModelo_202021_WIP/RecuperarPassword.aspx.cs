using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAlterarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string guid = Server.UrlDecode(Request["id"].ToString());
                string novapassword = tbPassword.Text;
                if (novapassword == String.Empty)
                    throw new Exception("");
                Utilizador utilizador = new Utilizador();
                utilizador.atualizarPassword(guid, novapassword);
                Response.Redirect("~/index.aspx");
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }
    }
}