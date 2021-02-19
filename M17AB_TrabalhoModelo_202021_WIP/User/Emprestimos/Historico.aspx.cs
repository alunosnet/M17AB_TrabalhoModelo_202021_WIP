using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.User.Emprestimos
{
    public partial class Historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "1")
                Response.Redirect("~/Index.aspx");

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            Emprestimo emprestimo = new Emprestimo();
            gvHistorico.DataSource = emprestimo.listaTodosEmprestimosComNomes(idutilizador);
            gvHistorico.DataBind();
        }
    }
}