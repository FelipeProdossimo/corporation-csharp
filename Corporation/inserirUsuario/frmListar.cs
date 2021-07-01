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
    public partial class frmListar : Form
    {
        public frmListar()
        {
            InitializeComponent();
        }

        private void frmUsuariosListagem_Load(object sender, EventArgs e)
        {
            //conexão com banco
            string bancoDeDados = "server=localhost;user id=root;password=;database=bd_projeto";
            MySqlConnection conexao = new MySqlConnection(bancoDeDados);

            try
            {
                //iniciando conexão
                conexao.Open();
                //Comando SQL para mostrar o banco de dados - referente a tb_clientes.

                //MySqlCommand cmd = new MySqlCommand();
                //cmd.Connection = conexao;
                //cmd.CommandText = "SELECT * FROM tb_clientes";
                //cmd.ExecuteNonQuery();
                string sqlSelecionar = "SELECT * FROM tb_usuarios";

                // Adaptador de dados p/ pegar informações do banco
                MySqlDataAdapter da = new MySqlDataAdapter(sqlSelecionar, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridUsuarios.DataSource = dt;
                conexao.Close();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("A conexão falhou. Erro: " + erro.Message, " erro na conexão");
            }
        }

        private void txtNomeProcurar_TextChanged(object sender, EventArgs e)
        {
            string bancoDeDados = "server=localhost;user id=root; password=;database=bd_corporation";
            MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                string nomeProcurar = txtNomeProcurar.Text;
                conexao.Open();
                string sqlSelecionar = $"SELECT * FROM tb_usuarios WHERE nome LIKE '%{nomeProcurar}%'";
                MySqlDataAdapter da = new MySqlDataAdapter(sqlSelecionar, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridUsuarios.DataSource = dt;
                conexao.Close();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("A conexão falhou. Erro: " + erro.Message, " erro na conexão");
            }
        }

        private void Pesquisar(string nome)
        {
            string sqlBuscar = "";
            sqlBuscar = $"SELECT * FROM tb_usuarios";

            string bancoDeDados = "server=localhost;user id=root;password=;database=bd_corporation;";

            MySqlConnection conexao = new MySqlConnection(bancoDeDados);
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sqlBuscar, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridUsuarios.DataSource = dt;
                conexao.Close();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show("A conexão falhou. Erro: " + erro.Message, " erro na conexão");
            }
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            // ABRIR FORMULÁRIO
            frmInserir formulario = new frmInserir();
            formulario.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // ABRIR FORMULÁRIO
            frmEditar formulario = new frmEditar();
            formulario.ShowDialog();
        }
    }
}
