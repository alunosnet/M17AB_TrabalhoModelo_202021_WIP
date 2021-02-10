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
    //TODO: Histórico de emprestimos
    public partial class Utilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:Validação da sessão do utilizador

            //configurar grid

            if (!IsPostBack)
                AtualizarGrid();
        }
        //atualizar a grid dos utilizadores
        private void AtualizarGrid()
        {
            //limpar gridview
            gvUtilizadores.Columns.Clear();
            gvUtilizadores.DataSource = null;
            gvUtilizadores.DataBind();

            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.ListaTodosUtilizadores();

            //TODO:completar

            gvUtilizadores.DataSource = dados;
            gvUtilizadores.DataBind();

        }
        //adicionar utilizadores
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //email
                string email = tbEmail.Text;
                if (email == String.Empty || email.Contains("@") == false || email.Contains(".") == false)
                    throw new Exception("O email indicado não é válido.");
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
                //perfil
                int perfil = int.Parse(ddPerfil.SelectedValue);
                if (perfil != 0 && perfil != 1)
                    throw new Exception("Perfil inválido!");
                //password
                string password = tbPassword.Text;
                if (password.Trim().Length < 5)
                    throw new Exception("A password é muito pequena.");

                //guardar na base de dados
                Utilizador utilizador = new Utilizador();
                utilizador.email = email;
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif;
                utilizador.password = password;
                utilizador.perfil = perfil;

                utilizador.Adicionar();

                //limpar o form
                tbNome.Text = "";
                tbEmail.Text = "";
                tbMorada.Text = "";
                tbNif.Text = "";
                tbPassword.Text = "";
                lbErro.Text = "Registo adicionado com sucesso.";
                ddPerfil.SelectedIndex = 0;

                //atualizar a grid
                AtualizarGrid();

            }
            catch (Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert";
                return;
            }

        }
    }
}