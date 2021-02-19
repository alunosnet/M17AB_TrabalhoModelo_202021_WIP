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
            
            //ordenar os livros?

            //atualizar grelha livros

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
                string mensagem = "Clique no link para recuperar a sua password.\n";
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
    }
}