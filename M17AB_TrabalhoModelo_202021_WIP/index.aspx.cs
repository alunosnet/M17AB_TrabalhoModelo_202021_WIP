using M17AB_TrabalhoModelo_202021_WIP.Classes;
using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Testar se tem login para esconder a divlogin
            if (Session["perfil"] != null)
                divLogin.Visible = false;

            //ordenar os livros?
            int? ordenar = 0;
            try
            {
                ordenar = int.Parse(Request["ordena"].ToString());
            }
            catch
            {
                ordenar = null;
            }
            //atualizar grelha livros
            atualizaListaLivros(null, ordenar);
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                UserLogin userLogin = new UserLogin();
                DataTable dados = userLogin.VerificaLogin(email, password);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("O login falhou.");
                //inicar sessão
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                //autorização
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/User.aspx");
            }
            catch
            {
                lbErro.Text = "Login falhou. Tente novamente.";
                lbErro.CssClass = "alert alert-danger";

            }
        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEmail.Text.Trim().Length == 0)
                    throw new Exception("Erro no email");
                string email = tbEmail.Text;
                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(email);
                if (dados == null || dados.Rows.Count == 0 || dados.Rows.Count > 1)
                    throw new Exception("Erro no email");
                Guid g = Guid.NewGuid();
                utilizador.recuperarPassword(email, g.ToString());
                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarPassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(g.ToString()) + "'>Clique aqui</a>";
                string meuemail = ConfigurationManager.AppSettings["MeuEmail"].ToString();
                string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"].ToString();

                Helper.enviarMail(meuemail, minhapassword, email, "Recuperação de password", mensagem);
                lbErro.Text = "Foi enviado um email";

            }
            catch
            {

            }
        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaListaLivros(tbPesquisa.Text);
        }

        private void atualizaListaLivros(string pesquisa=null,int? ordena=null)
        {
            Livro livro = new Livro();
            DataTable dados;
            if(pesquisa==null)
            {
                //se existir o cookie ultimolivro listar os livros do mesmo autor
                HttpCookie httpCookie = Request.Cookies["ultimolivro"];
                if (httpCookie == null)
                    dados = livro.listaLivrosDisponiveis(ordena);
                else
                    dados = livro.listaLivrosDoAutor(Server.UrlDecode(httpCookie.Value));
            }
            else
            {
                dados = livro.listaLivrosDisponiveis(pesquisa, ordena);
            }
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if(dados==null || dados.Rows.Count == 0)
            {
                divLivros.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow livro in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<img src='/Public/Images/" + livro[0].ToString() +
                    ".jpg' class='img-fluid'/>";
                grelha += "<p/><span class='stat-title'>" + livro[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(livro["preco"].ToString()))
                    + "</span>";
                grelha += "<br/><a href='detalheslivro.aspx?id=" + livro[0].ToString()
                    + "'>Detalhes</a>";
                grelha += "</div>";
            }
            grelha += "</div></div>";
            divLivros.InnerHtml = grelha;
        }
    }
}