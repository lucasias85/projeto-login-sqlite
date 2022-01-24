using System;
using System.Data;
using System.Data.SQLite;

namespace Projeto_Login_SQLite.Code.DAL
{
    class AcessarBancoDados
    {
        private SQLiteConnection conn;
        private DataTable dataTable;
        private SQLiteDataAdapter dataAdapter;
        private SQLiteDataReader dataReader;
        private SQLiteCommandBuilder commandBuilder;

        private string database = @"C:\Dev Projects\Dev C#\Projeto Login SQLite\Projeto Login SQLite\data\database_files.db";

        public void Conectar()
        {
            if (conn != null)
                conn.Close();

            string connStr = string.Format("Data Source = {0}", database);

            try
            {
                conn = new SQLiteConnection(connStr);
                conn.Open();
            }
            catch (SQLiteException ex)
            {

                throw new Exception("Erro ao tentar conectar banco de dados" + ex.Message);
            }
        }

        public void ExecutarComandoSQL(string comandoSQL)
        {
            SQLiteCommand cmd = new SQLiteCommand(comandoSQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable RetornarDataTable(string comandoSQL)
        {
            dataTable = new DataTable();
            dataAdapter = new SQLiteDataAdapter(comandoSQL, conn);
            commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public SQLiteDataReader RetornarDataReader(string comandoSQL)
        {
            SQLiteCommand cmd = new SQLiteCommand(comandoSQL, conn);
            dataReader = cmd.ExecuteReader();
            dataReader.Read();

            return dataReader;
        }
    }
}
