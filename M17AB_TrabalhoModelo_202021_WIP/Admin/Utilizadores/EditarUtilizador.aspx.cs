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
    public partial class EditarUtilizador : System.Web.UI.Page
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
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();

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
               
                //nome
                string nome = tbNome.Text;
                if (nome == String.Empty || nome.Trim().Length < 3)
                    throw new Exception("O nome indicado não é válido. Deve ter pelo menos 3 letras");
                //morada
                string morada = tbMorada.Text;
                if (morada == String.Empty || morada.Trim().Length < 3)
                    throw new Exception("A morada indicada não é válida. Deve ter pelo menos 3 letras");

                //nif
                string nif = tbNif.Text;
                int inif = int.Parse(nif);
                if (nif.Length != 9)
                    throw new Exception("O nif não é válido. Deve ter 9 digitos.");
            

                //guardar na base de dados
                Utilizador utilizador = new Utilizador();
                utilizador.id = int.Parse(Request["id"].ToString());
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif;

                utilizador.atualizarUtilizador();

                lbErro.Text = "Registo atualizado com sucesso.";
                Button1.Enabled = false;
                Redirecionar();
            }
            catch (Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
                return;
            }
        }
    }
}