using System;
using System.Windows.Forms;

namespace CRUD
{
    public partial class CadastroForm : Form
    {
        public string id, nome, sobrenome, email, telefone;

        public CadastroForm()
        {
            InitializeComponent();
        }

        // Método que modifica o form de cadastro pra um form de atualizar usuário.
        public void AtualizarUser()
        {
            label1.Text = "Editar Usuário";
            btnCadastrar.Text = "Atualizar";
            txtNome.Text = nome;
            txtSobrenome.Text = sobrenome;
            txtEmail.Text = email;
            txtFone.Text = telefone;
        }

        // Método pra limpar as inputs.
        public void Limpar()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFone.Text = string.Empty;
        }

        public void CadastroForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Você deve preencher todos os campos!");
            }
            else if (txtSobrenome.Text == "")
            {
                MessageBox.Show("Você deve preencher todos os campos!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Você deve preencher todos os campos!");
            }
            else if (txtFone.Text == "")
            {
                MessageBox.Show("Você deve preencher todos os campos!");
            }

            if (btnCadastrar.Text == "Cadastrar")
            {
                Usuario user = new Usuario(txtNome.Text, txtSobrenome.Text, txtEmail.Text, txtFone.Text);
                BancoDeDados.Cadastrar(user);
                Limpar();
                MessageBox.Show("Cadastro feito com sucesso!", "Atenção!");
            }
            else if (btnCadastrar.Text == "Atualizar")
            {
                Usuario userAtualizado = new Usuario(txtNome.Text, txtSobrenome.Text, txtEmail.Text, txtFone.Text);
                BancoDeDados.EditarUser(userAtualizado, id);
                MessageBox.Show("O usuário foi atualizado com sucesso!", "Atenção!");
            }
        }
        
        

    }
}
