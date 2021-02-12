using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores
{
    public partial class RemoverUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:validação da sessão do utilizador

            //postback
            if (IsPostBack) return;

            try
            {
                //id do utilizador na url
                int id = int.Parse(Request["id"].ToString());

                //ler na bd os dados
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                //mostrar ao utilizador
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbEmail.Text = dados.Rows[0]["email"].ToString();

            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                lbErro.CssClass = "alert alert-danger";
                Redirecionar();
            }
        }
        private void Redirecionar()
        {
            //redirecionar
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.removerUtilizador(id);
                lbErro.Text = "Utilizador removido com sucesso.";
            }
            catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
            Redirecionar();
        }
    }
}