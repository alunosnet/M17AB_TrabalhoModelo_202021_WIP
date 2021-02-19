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
    public partial class Livros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar a sessão do utilizador
            if (Session["perfil"] == null ||
                Session["perfil"].ToString() != "0")
                Response.Redirect("~/Index.aspx");

            ConfigurarGrid();

            if(!IsPostBack)
                AtualizarGrid();
        }
        private void ConfigurarGrid()
        {
            //paginação
            GvLivros.AllowPaging = true;
            GvLivros.PageSize = 5;
            GvLivros.PageIndexChanging += GvLivros_PageIndexChanging;
        }
        private void GvLivros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvLivros.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }
        private void AtualizarGrid()
        {
            GvLivros.Columns.Clear();
            Livro livro = new Livro();
            //consulta bd 
            DataTable dados = livro.ListaTodosLivros();

            //Adicionar duas colunas (remover/editar)
            DataColumn dcRemover = new DataColumn();
            dcRemover.ColumnName = "Remover";
            dcRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcRemover);

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            GvLivros.DataSource = dados;
            GvLivros.AutoGenerateColumns = false;

            //colunas da gridview
            //remover
            HyperLinkField hlRemover = new HyperLinkField();
            hlRemover.HeaderText = "Remover";   //cabeçalho da coluna
            hlRemover.DataTextField = "Remover";    //campo do datatable
            hlRemover.Text = "Remover";            //texto clicável
            hlRemover.DataNavigateUrlFormatString = "RemoverLivro.aspx?id={0}";
            hlRemover.DataNavigateUrlFields = new string[] { "nlivro" };
            GvLivros.Columns.Add(hlRemover);

            //editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar";
            hlEditar.DataNavigateUrlFormatString = "EditarLivro.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "nlivro" };
            GvLivros.Columns.Add(hlEditar);

            //nlivro
            BoundField bfNlivro = new BoundField();
            bfNlivro.HeaderText = "Nº Livro";
            bfNlivro.DataField = "nlivro";
            GvLivros.Columns.Add(bfNlivro);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            GvLivros.Columns.Add(bfNome);
            //ano
            BoundField bfAno = new BoundField();
            bfAno.HeaderText = "Ano";
            bfAno.DataField = "ano";
            GvLivros.Columns.Add(bfAno);
            //data aquisição
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data Aquisição";
            bfData.DataField = "data_aquisicao";
            bfData.DataFormatString = "{0:dd-MM-yyyy}";
            GvLivros.Columns.Add(bfData);

            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.HeaderText = "Preço";
            bfPreco.DataField = "preco";
            bfPreco.DataFormatString = "{0:C}";
            GvLivros.Columns.Add(bfPreco);

            //autor
            BoundField bfAutor = new BoundField();
            bfAutor.HeaderText = "Autor";
            bfAutor.DataField = "autor";
            GvLivros.Columns.Add(bfAutor);
            //tipo
            BoundField bfTipo = new BoundField();
            bfTipo.HeaderText = "Tipo";
            bfTipo.DataField = "tipo";
            GvLivros.Columns.Add(bfTipo);
            //estado
            BoundField bfEstado = new BoundField();
            bfEstado.HeaderText = "Estado";
            bfEstado.DataField = "estado";
            GvLivros.Columns.Add(bfEstado);
            //capa
            ImageField ifCapa = new ImageField();
            ifCapa.HeaderText = "Capa";
            int aleatorio = new Random().Next(999999);
            ifCapa.DataImageUrlFormatString = "~/Public/Images/{0}.jpg?" + aleatorio;
            ifCapa.DataImageUrlField = "nlivro";
            ifCapa.ControlStyle.Width = 100;
            GvLivros.Columns.Add(ifCapa);

            GvLivros.DataBind();
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            try
            {
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

                //capa
                if (FileUpload1.HasFile == false)
                    throw new Exception("Tem de indicar o ficheiro da capa");
                if (FileUpload1.PostedFile.ContentType != "image/jpeg" &&
                    FileUpload1.PostedFile.ContentType != "image/jpg" &&
                    FileUpload1.PostedFile.ContentType != "image/png")
                    throw new Exception("O formato do ficheiro da capa não é suportado.");
                if (FileUpload1.PostedFile.ContentLength == 0 ||
                    FileUpload1.PostedFile.ContentLength > 5000000)
                    throw new Exception("O tamanho do ficheiro não é válido.");

                //criar objeto livro
                Livro livro = new Livro();
                //preencher propriedades
                livro.ano = int.Parse(tbAno.Text);
                livro.autor = tbAutor.Text;
                livro.data_aquisicao = dataAquisicao;
                livro.estado = 1;
                livro.nome = tbNome.Text;
                livro.preco = decimal.Parse(tbPreco.Text);
                livro.tipo = tbTipo.Text;
                //guardar
                int idlivro = livro.Adicionar();

                //copiar o ficheiro
                string ficheiro = Server.MapPath(@"~\Public\Images\");
                ficheiro += idlivro + ".jpg";
                FileUpload1.SaveAs(ficheiro);

            }
            catch (Exception erro)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lbErro.CssClass = "alert";
                return;
            }
            //limpar
            tbAno.Text = "";
            tbAutor.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            tbTipo.Text = "";
            lbErro.Text = "";

            AtualizarGrid();
        }
    }
}