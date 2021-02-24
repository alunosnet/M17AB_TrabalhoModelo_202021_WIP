using M17AB_TrabalhoModelo_202021_WIP.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null || Session["perfil"].ToString() != "0")
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();
        }

        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                //Top de livros mais requisitados
                case 0:
                    sql = @"SELECT Nome,count(Emprestimos.nlivro) as [Nº de empréstimos] FROM Livros 
                            INNER JOIN Emprestimos ON Livros.nlivro=Emprestimos.nlivro 
                            GROUP BY Livros.nlivro,Livros.Nome
                            ORDER BY count(Emprestimos.nlivro) DESC";
                    break;
                //Top de leitores
                case 1:
                    sql = @"SELECT Nome,count(idutilizador) as [Nº de empréstimos] FROM Utilizadores 
                            INNER JOIN Emprestimos ON Utilizadores.id=Emprestimos.idutilizador 
                            GROUP BY Utilizadores.id,Utilizadores.Nome
                            ORDER BY count(idutilizador) DESC";
                    break;
                //1-Top de livros mais requisitados do último mês
                case 2:
                    sql = @"";
                    break;
                //2-Lista de utilizadores com livros fora de prazo 
                case 3:
                    sql = @"SELECT utilizadores.nome as [Nome do Leitor],livros.nome as [Nome Livro],
                            data_emprestimo,data_devolve,DATEDIFF(DAY,emprestimos.data_devolve,getdate()) as [Dias fora de prazo]
                            FROM Emprestimos 
                            INNER JOIN livros 
                                ON emprestimos.nlivro=livros.nlivro
                            INNER JOIN utilizadores 
                                ON emprestimos.idutilizador=utilizadores.id 
                            WHERE DATEDIFF(DAY,emprestimos.data_devolve,getdate()) >= 1 AND emprestimos.estado = 1";
                    break;
                //3-Livros da última semana - novidades 
                case 4:
                    sql = @"";
                    break;
                //4-Tempo médio de empréstimo 
                case 5:
                    sql = @"";
                    break;
                //5-Nº de livros por autor
                case 6:
                    sql = @"";
                    break;
                //6- Nº de utilizadores bloqueados
                case 7:
                    sql = @"";
                    break;
                //7-Nº de tipos de livro por utilizador
                case 8:
                    sql = @"";
                    break;
                //8-Nº de empréstimos por mês
                case 9:
                    sql = @"";
                    break;
                //9-Lista dos utilizadores que requisitaram o livro mais caro
                case 10:
                    sql = @"SELECT utilizadores.nome as [Nome dos Utilizadores], livros.nome as [Nome do Livro], max(livros.preco) as [Preço] FROM utilizadores
                            INNER JOIN emprestimos on utilizadores.id = emprestimos.idutilizador
                            INNER JOIN livros ON emprestimos.nlivro = livros.nlivro 
                            GROUP BY utilizadores.nome, livros.nome
                            ORDER BY max(livros.preco) DESC";
                    break;
                //10-Lista dos livros cujo preço é superior à média
                case 11:
                    sql = @"";
                    break;
                //11- Lista dos utilizadores com a mesma password
                case 12:
                    sql = @"";
                    break;
            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }
    }
}