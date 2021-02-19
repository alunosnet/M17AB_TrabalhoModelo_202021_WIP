using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//TODO: só fazer quando os empréstimos estiverem a funcionar
namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores
{
    public partial class HistoricoUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("~/Index.aspx");
            try
            {
                atualizarGrid();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe";
                lbErro.CssClass = "alert alert-danger";
                Redirecionar();
            }
        }

        private void atualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Request["id"].ToString());
            Emprestimo emprestimo = new Emprestimo();
            gvHistorico.DataSource = emprestimo.listaTodosEmprestimosComNomes(id);
            gvHistorico.DataBind();
        }

        private void Redirecionar()
        {
            //redirecionar
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
        }
    }
}