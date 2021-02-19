using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }

        private void MostrarPerfil()
        {
            Utilizador utilizador = new Utilizador();
            int id = int.Parse(Session["id"].ToString());
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbMorada.Text = dados.Rows[0]["morada"].ToString();
                lbNif.Text = dados.Rows[0]["nif"].ToString();

            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
            lbErro.Text = "";
            lbErro.CssClass = "";
            
        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Session["id"].ToString());
                string nome = tbNome.Text;
                string morada = tbMorada.Text;
                int nif = int.Parse(tbNif.Text);
                //validar dados
                if (nome.Trim().Length == 0)
                    throw new Exception("O nome indicado não é válido");
                if (morada.Trim().Length == 0)
                    throw new Exception("A morada indicada não é válida");
                if (tbNif.Text.Trim().Length != 9)
                    throw new Exception("O nif indicado não é válido");
                Utilizador utilizador = new Utilizador();
                utilizador.id = id;
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif.ToString();
                utilizador.atualizarUtilizador();
                divEditar.Visible = false;
                divPerfil.Visible = true;
                MostrarPerfil();
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
            lbErro.Text = "";
            lbErro.CssClass = "";
        }
    }
}