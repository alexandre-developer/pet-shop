using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class Formulario : Form
    {
        SqlConnection sqlConn = null;
        private string strConn = "Data Source=DESKTOP-UE2G19Q;Initial Catalog=dbcrude;Integrated Security=True";
        private string _sql = string.Empty;
        public bool logado = false;

        public Formulario()
        {
            InitializeComponent();
        }

        private void Formulario_Load(object sender, EventArgs e)
        {

        }

            public void logar()
        {

            try
                {
                sqlConn = new SqlConnection(strConn);
                string usu, sen;
                usu = txt_usuario.Text;
                sen = txt_senha.Text;

                _sql = "Select COUNT(idusuario) FROM usuarios WHERE usuario = @usuario AND senha = @senha";
                SqlCommand cmd = new SqlCommand(_sql, sqlConn);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usu;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = sen;

                sqlConn.Open();

                //farei um cast
                int v = (int)cmd.ExecuteScalar();
                if (v > 0)
                {
                    logado = true;
                    MessageBox.Show("logado com sucesso");
                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Erro ao logar");
                }
            }
            catch(SqlException ero)
            {
                MessageBox.Show(ero+"Erro ao se conecatar");
            }

        }

        private void btnlogar_Click(object sender, EventArgs e)
        {
            logar();
        }
    }
}
