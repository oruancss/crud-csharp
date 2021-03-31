using System;
using System.Windows.Forms;

namespace CRUD
{
    public partial class CrudCsharp : Form
    {
        CadastroForm form;

        public CrudCsharp()
        {
            InitializeComponent();
            form = new CadastroForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            form.ShowDialog();            
        }

        // Método que seleciona as informações da database para mostrar no dataGridView1.
        public void Infos()
        {
            BancoDeDados.Pesquisar("SELECT ID, Nome, Sobrenome, Email, Telefone FROM cadastrados", dataGridView1);
        }
        // Interage com o método pesquisar pra buscar usuários no banco de dados
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BancoDeDados.Pesquisar("SELECT ID, Nome, Sobrenome, Email, Telefone FROM cadastrados WHERE Nome LIKE '%" + textBox1.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Abre a aba de editar, chama o método AtualizarUser que modifica o CadastroForm.
            if (e.ColumnIndex == 0)
            {
                form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.nome = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.sobrenome = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.email = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.telefone = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.AtualizarUser();
                form.ShowDialog();
                return;
            }

            // Deleta usuário.
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Você realmente quer deletar esse usuário?", "Atenção!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    BancoDeDados.ApagarUser(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Infos();
                }
                return;
            }
        }

        // Chama o método info que seleciona as informações do usuário na database e mostra no dataGridView1.
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Infos();
        }
    }
}
