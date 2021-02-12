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

            ConfigurarGrid();

            if (!IsPostBack)
                AtualizarGrid();
        }

        private void ConfigurarGrid()
        {
            //paginação
            gvUtilizadores.AllowPaging = true;
            gvUtilizadores.PageSize = 5;
            gvUtilizadores.PageIndexChanging += GvUtilizadores_PageIndexChanging;
        }

        private void GvUtilizadores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUtilizadores.PageIndex = e.NewPageIndex;
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

            gvUtilizadores.DataSource = dados;
            gvUtilizadores.AutoGenerateColumns = false;

            //remover
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);
            //editar
            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);
            //bloquear
            DataColumn dcBloquear = new DataColumn();
            dcBloquear.ColumnName = "Bloquear";
            dcBloquear.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcBloquear);
            //histórico
            DataColumn dcHistorico = new DataColumn();
            dcHistorico.ColumnName = "Historico";
            dcHistorico.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcHistorico);

            //Formatação Gridview
            //remover
            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";
            hlRemover.DataTextField = "Remover";    //columnname do datatable
            hlRemover.Text = "Remover";
            //RemoverUtilizador.aspx?id={0}
            hlRemover.DataNavigateUrlFormatString = "RemoverUtilizador.aspx?id={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizadores.Columns.Add(hlRemover);
            //editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";    //columnname do datatable
            hlEditar.Text = "Editar";
            hlEditar.DataNavigateUrlFormatString = "EditarUtilizador.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizadores.Columns.Add(hlEditar);
            //bloquear
            HyperLinkField hlBloquear = new HyperLinkField();
            hlBloquear.HeaderText = "Bloquear";
            hlBloquear.DataTextField = "Bloquear";    //columnname do datatable
            hlBloquear.Text = "Bloquear";
            hlBloquear.DataNavigateUrlFormatString = "BloquearUtilizador.aspx?id={0}";
            hlBloquear.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizadores.Columns.Add(hlBloquear);
            //histórico
            HyperLinkField hlHistorico = new HyperLinkField();
            hlHistorico.HeaderText = "Histórico";
            hlHistorico.DataTextField = "Historico";    //columnname do datatable
            hlHistorico.Text = "Histórico";
            hlHistorico.DataNavigateUrlFormatString = "HistoricoUtilizador.aspx?id={0}";
            hlHistorico.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizadores.Columns.Add(hlHistorico);

            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "Id";
            bfId.DataField = "id";
            bfId.Visible = false;
            gvUtilizadores.Columns.Add(bfId);
            //email
            BoundField bfEmail = new BoundField();
            bfEmail.HeaderText = "Email";
            bfEmail.DataField = "email";
            gvUtilizadores.Columns.Add(bfEmail);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            gvUtilizadores.Columns.Add(bfNome);
            //Morada
            BoundField bfMorada = new BoundField();
            bfMorada.HeaderText = "Morada";
            bfMorada.DataField = "morada";
            gvUtilizadores.Columns.Add(bfMorada);
            //nif
            BoundField bfNif = new BoundField();
            bfNif.HeaderText = "Nif";
            bfNif.DataField = "nif";
            gvUtilizadores.Columns.Add(bfNif);
            //estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            gvUtilizadores.Columns.Add(bfEstado);
            //perfil
            BoundField bfPerfil = new BoundField();
            bfPerfil.HeaderText = "Perfil";
            bfPerfil.DataField = "perfil";
            gvUtilizadores.Columns.Add(bfPerfil);
            //Como fazer para aparecer a palavra Admin ou utilizador em vez 0 e 1?

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
                lbErro.CssClass = "alert alert-danger";
                return;
            }

        }
    }
}