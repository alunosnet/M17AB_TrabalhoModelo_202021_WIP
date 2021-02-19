using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.User.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "1")
                Response.Redirect("~/Index.aspx");

            ConfigurarGrid();

            AtualizarGrid();
        }
        private void ConfigurarGrid()
        {
            gvLivros.RowCommand += GvLivros_RowCommand;
        }

        private void GvLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //chamado para reserva do livro
            //linha
            int linha = int.Parse(e.CommandArgument as string);
            //id livro
            int idlivro = int.Parse(gvLivros.Rows[linha].Cells[1].Text);
            //id utilizador
            int idutilizador = int.Parse(Session["id"].ToString());
            if (e.CommandName == "reservar")
            {
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.adicionarReserva(idlivro, idutilizador, DateTime.Now.AddDays(7));
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            gvLivros.Columns.Clear();
            gvLivros.DataSource = null;
            gvLivros.DataBind();

            Livro livro = new Livro();
            gvLivros.DataSource = livro.listaLivrosDisponiveis();

            //botão reservar
            ButtonField btReservar = new ButtonField();
            btReservar.HeaderText = "Reservar livro";
            btReservar.Text = "Reservar";
            btReservar.ButtonType = ButtonType.Button;
            btReservar.CommandName = "reservar";
            btReservar.ControlStyle.CssClass = "btn btn-danger";
            gvLivros.Columns.Add(btReservar);

            gvLivros.DataBind();

        }

       
    }
}