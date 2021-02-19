using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Livros
{
    public partial class RemoverLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("~/Index.aspx");

            try
            {
                int id = int.Parse(Request["id"].ToString());
                Livro livro = new Livro();
                DataTable dados = livro.devolveDadosLivro(id);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("Erro");
                lbNlivro.Text = dados.Rows[0]["nlivro"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                string ficheiro = @"~\Public\Images\" + id + ".jpg";
                imgCapa.ImageUrl = ficheiro;
            }
            catch
            {
                Response.Redirect("~/Admin/Livros/Livros.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Livro livro = new Livro();
                livro.removerLivro(id);
                string ficheiro = @"~\Public\Images\" + id + ".jpg";
                ficheiro = Server.MapPath(ficheiro);
                File.Delete(ficheiro);
                lbErro.Text = "Livro removido com sucesso.";
                btRemover.Enabled = false;
                btRemover.Attributes.Add("disabled", "true");
            }
            catch (Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                "Redirecionar", "returnMain('/Admin/Livros/Livros.aspx')", true);
        }
    }
}