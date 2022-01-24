namespace Projeto_Login_SQLite.Code.DTO
{
    class UsuarioDTO
    {
        private int id_usuario;
        private string nomecompleto;
        private string login;
        private string senha;
        private string situacao;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nomecompleto { get => nomecompleto; set => nomecompleto = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Situacao { get => situacao; set => situacao = value; }
    }
}
