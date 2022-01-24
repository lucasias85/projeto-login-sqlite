using Projeto_Login_SQLite.Code.DAL;
using Projeto_Login_SQLite.Code.DTO;
using System;
using System.Data.SQLite;

namespace Projeto_Login_SQLite.Code.BLL
{
    class UsuarioBLL
    {
        AcessarBancoDados bd;

        public void Inserir(UsuarioDTO dto)
        {

        }

        public SQLiteDataReader SelecionarUsuario(UsuarioDTO dto)
        {
            SQLiteDataReader dataReader;

            try
            {
                bd = new AcessarBancoDados();
                bd.Conectar();

                string comando = string.Format("SELECT login, senha FROM usuarios WHERE login = '{0}' AND senha = '{1}'", dto.Login, dto.Senha);
                dataReader = bd.RetornarDataReader(comando);

                return dataReader;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar login e/ou senha" + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }
    }
}
