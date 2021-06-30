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
    public partial class frmInserir : Form
    {
        public frmInserir()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarUsuario(txtNome.Text, txtSobrenome.Text, txtEmail.Text, txtTelefone.Text);
            LimparFormulario();
        }
        private void LimparFormulario()
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }
        private void CadastrarUsuario(string nome, string sobrenome, string email, string telefone)
        {
            string bancoDeDados = "server=localhost;user id=root;password=;database=bd_corporation";
            ; MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO tb_usuarios(nome, sobrenome, email, telefone) VALUES ('" + txtNome.Text + "'," +
                    " '" + txtSobrenome.Text + "' , '" + txtEmail.Text + "', '" + txtTelefone.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario cadastrado com sucesso!");
                conexao.Close();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("Não foi possivel conectar com o banco de dados: " + erro.Message);
            }
        }
    }
}
