using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores
{
    public partial class BloquearUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: validar sessão do utilizador

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.ativarDesativarUtilizador(id);
                Response.Redirect("/Admin/Utilizadores/Utilizadores.aspx");
                
            }
            catch
            {
                Response.Redirect("/Admin/Utilizadores/Utilizadores.aspx");
            }
        }
    }
}