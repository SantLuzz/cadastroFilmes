using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace filmes
{
    internal class db
    {
        public static string local = System.Environment.CurrentDirectory;
        public static string Base = @"\db\";
        public static string nomeBase = "db_filmes.db";
        public static string existsDB = local + Base;
        

        private static SQLiteConnection ConnectDB()
        {
            var conect = new SQLiteConnection("Data Source =" + local + Base + nomeBase);
            conect.Open();
            return conect;
        }

        public static DataTable dql(string sql)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = null;
            try
            {
                var vCon = ConnectDB();
                var cmd = vCon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vCon);
                da.Fill(dt);
                vCon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void dml(string sql,string msgOk = null,string msgError = null)
        {
            SQLiteDataAdapter da = null;

            try
            {
                var vCon = ConnectDB();
                var cmd = vCon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vCon);
                cmd.ExecuteNonQuery();
                vCon.Close();
                if (msgOk != null)
                {
                    MessageBox.Show(msgOk, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (msgError != null)
                {
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw ex;
            }
        }
        
        public static void createTableFilme()
        {
            SQLiteDataAdapter da = null;

            try
            {
                var vCon = ConnectDB();
                var cmd = vCon.CreateCommand();
                cmd.CommandText = String.Format(@"
                    CREATE TABLE IF NOT EXISTS tb_filmes(
                    idFilme INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    nome VARCHAR(50),
                    descricao VARCHR(255),
                    idCat INTEGER REFERENCES tb_categoria(idCat) ON DELETE SET NULL)
                ");
                da = new SQLiteDataAdapter(cmd.CommandText, vCon);
                cmd.ExecuteNonQuery();
                vCon.Close();
                //MessageBox.Show("Tabela FIlmes Criada!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void createTableCategoria()
        {
            SQLiteDataAdapter da = null;

            try
            {
                var vCon = ConnectDB();
                var cmd = vCon.CreateCommand();
                cmd.CommandText = String.Format(@"
                    CREATE TABLE IF NOT EXISTS tb_categoria(
                        idCat INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                        nome VARCHAR(50),
                        descricao VARCHAR(255))
                ");
                da = new SQLiteDataAdapter(cmd.CommandText, vCon);
                cmd.ExecuteNonQuery();
                vCon.Close();
                //MessageBox.Show("Tabela Categoria Criada!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void createTables()
        {
            createTableFilme();
            createTableCategoria();
        }

    }
}
