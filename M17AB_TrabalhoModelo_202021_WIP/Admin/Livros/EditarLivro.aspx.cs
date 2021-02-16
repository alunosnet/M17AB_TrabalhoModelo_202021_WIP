using M17AB_TrabalhoModelo_202021_WIP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_202021_WIP.Admin.Livros
{
    public partial class EditarLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão do utilizador

            if (IsPostBack) return;
            //carregar os dados do livro a editar
            try
            {
                int nlivro = int.Parse(Request["id"].ToString());
                Livro livro = new Livro();
                DataTable dados = livro.devolveDadosLivro(nlivro);
                if (dados == null || dados.Rows.Count == 0)
                    throw new Exception("Erro");

                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbAno.Text = dados.Rows[0]["ano"].ToString();
                tbAutor.Text = dados.Rows[0]["autor"].ToString();
                tbPreco.Text =dados.Rows[0]["preco"].ToString().Replace(',','.');
                tbTipo.Text = dados.Rows[0]["tipo"].ToString();
                tbData.Text =DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");

                string ficheiro = @"~\Public\Images\" + nlivro + ".jpg";
                imgCapa.ImageUrl = ficheiro;
            }
            catch
            {
                lbErro.Text = "O livro indicado não existe.";
                //redirecionar para livros
                ScriptManager.RegisterStartupScript(this,
                    typeof(Page), "Redirecionar",
                "returnMain('/Admin/Livros/Livros.aspx');", true);
            }
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            try
            {
                //validar o form
                //validar nome(100)
                string nome = tbNome.Text.Trim();
                if (nome == String.Empty || nome.Length < 2
                  || nome.Length > 100)
                    throw new Exception("O nome deve ter pelo menos 2 letras e no máximo 100.");

                //validar o ano
                int iano = 0;
                if (int.TryParse(tbAno.Text, out iano) == false)
                    throw new Exception("O ano indicado não é valido.Deve ser um valor numérico.");

                if (iano <= 0 || iano > DateTime.Now.Year)
                    throw new Exception("O ano de edição do livro tem de ser superior a 0 e inferior ou igual ao ano atual.");

                //validar a data_aquisicao
                DateTime dataAquisicao = DateTime.Parse(tbData.Text);
                if (dataAquisicao > DateTime.Now)
                    throw new Exception("A data não é válida. Tem de ser inferior ou igual à data atual");

                //validar preco (4,2)
                Decimal preco = 0;
                if (Decimal.TryParse(tbPreco.Text, out preco) == false)
                    throw new Exception("O preço indicado não é válido. Deve ser um valor numérico.");

                if (preco < 0 || preco >= 100)
                    throw new Exception("O preço não é válido. Tem de estar entre 0 e 99,99");


                //validar o autor (100)
                string autor = tbAutor.Text.Trim();
                if (autor == String.Empty || autor.Length < 2 ||
                    autor.Length > 100)
                    throw new Exception("O autor deve ter pelo menos 2 letras e no máximo 100.");
                //validar o tipo (50)
                string tipo = tbTipo.Text.Trim();
                if (tipo == String.Empty || tipo.Length > 50)
                    throw new Exception("O tipo deve ter entre 2 e 50 letras.");

                //id livro
                int nlivro = int.Parse(Request["id"].ToString());
                Livro livro = new Livro();
                livro.nlivro = nlivro;
                livro.nome = tbNome.Text;
                livro.ano = int.Parse(tbAno.Text);
                livro.preco = decimal.Parse(tbPreco.Text);
                livro.tipo = tbTipo.Text;
                livro.autor = tbAutor.Text;
                livro.data_aquisicao = dataAquisicao;

                if (FileUpload1.HasFile)
                {
                    //validar o ficheiro
                    if (FileUpload1.PostedFile.ContentType != "image/jpeg" &&
                        FileUpload1.PostedFile.ContentType != "image/jpg" &&
                        FileUpload1.PostedFile.ContentType != "image/png")
                            throw new Exception("O formato do ficheiro da capa não é suportado.");
                    if (FileUpload1.PostedFile.ContentLength == 0 ||
                        FileUpload1.PostedFile.ContentLength > 5000000)
                        throw new Exception("O tamanho do ficheiro não é válido.");

                    //copiar o ficheiro
                    string ficheiro = Server.MapPath(@"~\Public\Images\");
                    ficheiro += nlivro + ".jpg";
                    FileUpload1.SaveAs(ficheiro);
                }
                //atualizar o livro
                livro.atualizaLivro();
                //mostrar mensagem e redirecionar
                lbErro.Text = "O livro foi atualizado com sucesso.";
                bt1.Enabled = false;
                //redirecionar para livros
                ScriptManager.RegisterStartupScript(this,
                    typeof(Page), "Redirecionar",
                "returnMain('/Admin/Livros/Livros.aspx');", true);
            }
            catch (Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
            }
        }
    }
}