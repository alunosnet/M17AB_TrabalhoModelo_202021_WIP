using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO:validar a sessão do utilizador

            configurarGrid();
            
            if (IsPostBack) return;

            atualizarGrid();
            atualizarDDLivros();
            atualizarDDUtilizadores();
        }
        protected void cbEmprestimos_CheckedChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void atualizarDDUtilizadores()
        {
            Utilizador utilizador = new Utilizador();
            ddUtilizadores.Items.Clear();
            DataTable dados = utilizador.listaTodosUtilizadoresDisponiveis();
            foreach(DataRow r in dados.Rows){
                ddUtilizadores.Items.Add(
                    new ListItem(r["nome"].ToString(),r["id"].ToString())    
                );
            }
        }
        private void atualizarDDLivros()
        {
            Livro livro = new Livro();
            ddLivros.Items.Clear();
            DataTable dados = livro.listaLivrosDisponiveis();
            foreach(DataRow r in dados.Rows)
            {
                ddLivros.Items.Add(
                    new ListItem(r["nome"].ToString(), r["nlivro"].ToString())   
                );
            }
        }

        private void configurarGrid()
        {
            //paginação
            gvEmprestimos.AllowPaging = true;
            gvEmprestimos.PageSize = 5;
            gvEmprestimos.PageIndexChanging += GvEmprestimos_PageIndexChanging;
            //botões de comando
            gvEmprestimos.RowCommand += GvEmprestimos_RowCommand;
            gvEmprestimos.RowDataBound += GvEmprestimos_RowDataBound;
        }
        //executado para cada linha adicionada à grid
        private void GvEmprestimos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        //event listener do click nos botões de comando da grid
        private void GvEmprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //quando muda de página na grid
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument as string);
            //idemprestimo
            int idEmprestimo = int.Parse(gvEmprestimos.Rows[linha].Cells[2].Text);

            if (e.CommandName == "alterar")
            {
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.alterarEstadoEmprestimo(idEmprestimo);
                atualizarDDLivros();
                atualizarGrid();
            }
            if (e.CommandName == "email")
            {

            }
        }

        private void GvEmprestimos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmprestimos.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            Emprestimo emprestimo = new Emprestimo();
            gvEmprestimos.Columns.Clear();
            gvEmprestimos.DataSource = null;
            gvEmprestimos.DataBind();

            DataTable dados;
            if (cbEmprestimos.Checked)
                dados = emprestimo.listaTodosEmprestimosPorConcluirComNomes();
            else
                dados = emprestimo.listaTodosEmprestimosComNomes();

            if (dados == null || dados.Rows.Count == 0) return;
            //botões de comando
            //alterar o estado do empréstimo
            ButtonField btEstado = new ButtonField();
            btEstado.HeaderText = "Receber livro";
            btEstado.Text = "Receber";
            btEstado.ButtonType = ButtonType.Button;
            btEstado.ControlStyle.CssClass = "btn btn-info";
            btEstado.CommandName = "alterar";
            gvEmprestimos.Columns.Add(btEstado);
            //enviar o email
            ButtonField btEmail = new ButtonField();
            btEmail.HeaderText = "Notificar";
            btEmail.Text = "Email";
            btEmail.ButtonType = ButtonType.Button;
            btEmail.ControlStyle.CssClass= "btn btn-danger";
            btEmail.CommandName = "email";
            gvEmprestimos.Columns.Add(btEmail);

            gvEmprestimos.DataSource = dados;
            gvEmprestimos.AutoGenerateColumns = true;
            gvEmprestimos.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Emprestimo emprestimo = new Emprestimo();
                int idLivro = int.Parse(ddLivros.SelectedValue);
                int idUtilizador = int.Parse(ddUtilizadores.SelectedValue);
                DateTime dataDevolve = DateTime.Parse(tbData.Text);
                emprestimo.adicionarEmprestimo(idLivro, idUtilizador, dataDevolve);

                atualizarGrid();
                atualizarDDLivros();
                atualizarDDUtilizadores();
                lbErro.Text = "Empréstimo registado com sucesso.";
            }catch(Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}