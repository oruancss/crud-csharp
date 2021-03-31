using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD
{
    class BancoDeDados
    {

        public static MySqlConnection Conectar()
        {
            var acesso = "datasource=localhost;port=3306;username=root;password=;database=cad_user";
            MySqlConnection conectaDB = new MySqlConnection(acesso);

            try
            {
                conectaDB.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conectaDB;
        }

        public static void Cadastrar(Usuario user)
        {
            string insertUser = "INSERT INTO cadastrados VALUES (NULL, @Nome, @Sobrenome, @Email, @Telefone)";
            MySqlConnection conectarDB = Conectar();

            MySqlCommand cadastrar = new MySqlCommand(insertUser, conectarDB);
            cadastrar.CommandType = CommandType.Text;

            cadastrar.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = user.Nome;
            cadastrar.Parameters.Add("@Sobrenome", MySqlDbType.VarChar).Value = user.Sobrenome;
            cadastrar.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
            cadastrar.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = user.Telefone;

            try
            {
                cadastrar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conectarDB.Close();
            }

        
        }

        public static void ApagarUser(string id)
        {
            string insertUser = "DELETE FROM cadastrados WHERE ID = @Id";
            MySqlConnection conectarDB = Conectar();

            MySqlCommand deletar = new MySqlCommand(insertUser, conectarDB);
            deletar.CommandType = CommandType.Text;
            deletar.Parameters.Add("@Id", MySqlDbType.VarChar).Value = id;


            try
            {
                deletar.ExecuteNonQuery();
                MessageBox.Show("O usuário foi deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conectarDB.Close();
            }
        }

        public static void EditarUser(Usuario user, string id)
        {
            string insertUser = "UPDATE cadastrados SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";
            MySqlConnection conectarDB = Conectar();

            MySqlCommand editar = new MySqlCommand(insertUser, conectarDB);
            editar.CommandType = CommandType.Text;

            editar.Parameters.Add("@Id", MySqlDbType.VarChar).Value = id;
            editar.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = user.Nome;
            editar.Parameters.Add("@Sobrenome", MySqlDbType.VarChar).Value = user.Sobrenome;
            editar.Parameters.Add("@Email", MySqlDbType.VarChar).Value = user.Email;
            editar.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = user.Telefone;

            try
            {
                editar.ExecuteNonQuery();
                MessageBox.Show("O usuário foi atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conectarDB.Close();
            }
        }


        public static void Pesquisar(string letras, DataGridView infos)
        {
            string sql = letras;
            MySqlConnection conectarDB = Conectar();
            MySqlCommand pesquisa = new MySqlCommand(sql, conectarDB);
            MySqlDataAdapter adp = new MySqlDataAdapter(pesquisa);
            DataTable tabelaDados = new DataTable();
            adp.Fill(tabelaDados);
            infos.DataSource = tabelaDados;
            conectarDB.Close();
        }
    }
}
