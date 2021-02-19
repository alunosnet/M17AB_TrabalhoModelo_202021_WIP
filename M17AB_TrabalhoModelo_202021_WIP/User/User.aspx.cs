using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "1")
                Response.Redirect("~/Index.aspx");
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}