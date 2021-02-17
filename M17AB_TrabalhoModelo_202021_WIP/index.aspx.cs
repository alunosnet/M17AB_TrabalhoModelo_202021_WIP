using System;
using System.Collections.Generic;
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

            }
            catch
            {

            }
        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {

        }
    }
}