using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inserirUsuario
{
    public partial class AlteraExcluiUsuario : Form
    {
        public AlteraExcluiUsuario()
        {
            InitializeComponent();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string bancoDeDados = "server=localhost;user id=root;password=;database=bd_corporation;";
            MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                conexao.Open();
                string sqlAlterar = $"UPDATE tb_clientes set nome='{txtNome.Text}'  , sobrenome='{txtSobrenome.Text}', email='{txtEmail.Text}' , " +
                    $"telefone='{txtTelefone.Text}' WHERE id={txtID.Text}";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = sqlAlterar;
                cmd.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Alterado com sucesso");
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Algum erro ocorreu. Erro: " + erro.Message);
            }
        }
    }
}
