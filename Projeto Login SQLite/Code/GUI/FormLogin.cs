using Projeto_Login_SQLite.Code.BLL;
using Projeto_Login_SQLite.Code.DTO;
using Projeto_Login_SQLite.Code.GUI;
using System;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;

namespace Projeto_Login_SQLite
{
    public partial class FormLogin : Form
    {
        UsuarioBLL bll = new UsuarioBLL();
        UsuarioDTO dto = new UsuarioDTO();
        Thread novaThread;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            SQLiteDataReader dataReader;

            dto.Login = textBoxLogin.Text;
            dto.Senha = textBoxSenha.Text;
            dataReader = bll.SelecionarUsuario(dto);

            if (dataReader.HasRows)
            {
                this.Close();
                novaThread = new Thread(novoForm);
                novaThread.SetApartmentState(ApartmentState.STA);
                novaThread.Start();
            }
            else
            {
                var result = MessageBox.Show("Nome de usuário e/ou senha inválidos !!!\n\nDeseja tentar novamente?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    textBoxLogin.Clear();
                    textBoxSenha.Clear();
                    textBoxLogin.Focus();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void novoForm()
        {
            Application.Run(new FormPrincipal());
        }
    }
}
