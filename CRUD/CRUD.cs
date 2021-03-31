using System;
using System.Windows.Forms;

namespace CRUD
{
    static class CRUD
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CrudCsharp());
        }
    }

    class Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Usuario (string nome, string sobrenome, string email, string telefone)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
        }
    }
}
