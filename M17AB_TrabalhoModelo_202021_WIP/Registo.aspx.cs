using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string nome = tbNome.Text;
                string morada = tbMorada.Text;
                string nif = tbNif.Text;
                string password = tbPassword.Text;
                //validar dados

                //validar recaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var evalido = ReCaptcha.Validate(respostaRecaptcha);
                if (evalido == false)
                    throw new Exception("Tem de provar que não é o Mr. Robot.");

                //registar o utilizador
                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.morada = morada;
                utilizador.password = password;
                utilizador.perfil = 1;
                utilizador.nif = nif;
                utilizador.Adicionar();
                lbErro.Text = "Registado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                    "returnMain('/index.aspx');", true);
            }catch(Exception erro)
            {
                lbErro.Text="Ocorreu o seguinte erro: "+erro.Message;
                lbErro.CssClass = "alert alert-danger";
            }
        }
    }
}