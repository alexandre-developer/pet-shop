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

namespace Pet_Shop
{
    public partial class frm_login : Form
    {
        private const string strConn = "Data Source=DESKTOP-UE2G19Q;Initial Catalog=dbcrude;Integrated Security=True";
        public bool logado = false;
        private string _sql = string.Empty;

        SqlConnection sqlConn = null;

        public frm_login()
        {
            InitializeComponent();
        }

        public void logar()
        {
            try
            {
                sqlConn = new SqlConnection(strConn);
                string usu, sen;

                usu = txtusuario.Text;
                sen = txtsenha.Text;

                _sql = "SELECT COUNT(idusuario) FROM usuarios WHERE usuario = @usuario AND senha = @senha";
                SqlCommand cmd = new SqlCommand(_sql, sqlConn);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usu;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = sen;

                sqlConn.Open();

                int v = (int)cmd.ExecuteScalar();
                 if (v > 0)
                {
                    logado = true;
                    MessageBox.Show("Logado com sucesso");
                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Erro ao Logar");
                }

            }
            catch (Exception erro)
            {

                MessageBox.Show(erro + "Erro ao logar");
            }
        }

        private void btnlogar_Click(object sender, EventArgs e)
        {
            logar();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            conexao_petshop teste = new conexao_petshop();
            if (teste.Conectado())
            {
                MessageBox.Show("Conectado garoto");
            }
            else
            {
                MessageBox.Show("Não conectado garoto");
            }
        }
    }
}
