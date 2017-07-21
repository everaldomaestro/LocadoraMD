using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.ObjectModel;
using Contratos.Connect;
using System.Data.SqlClient;
using System.Data;

namespace Controller.DAO
{
    public class FilmeAluguelDAO : IDAO<FilmeAluguel>
    {
        private IConnection _connection;
        SqlCommand cmd;
        Collection<FilmeAluguel> FilmesAluguel = new Collection<FilmeAluguel>();
        FilmeAluguel FilmeAluguel;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable tblFilmeAluguel = new DataTable();

        public FilmeAluguelDAO(IConnection Connection)
        {
            _connection = Connection;
        }

        public void Atualizar(FilmeAluguel model)//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE FilmeAluguel SET " +
                    "FilmeID=@FilmeID," +
                    "ValorFilme=@ValorFilme," +
                    "QTD=@QTD," +
                    "AluguelID=@AluguelID " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@FilmeID", SqlDbType.Date).Value =
                    model.FilmeID;
                cmd.Parameters.Add("@ValorFilme", SqlDbType.Date).Value =
                    model.ValorFilme;
                cmd.Parameters.Add("@QTD", SqlDbType.Date).Value =
                    model.QTD;
                cmd.Parameters.Add("@AluguelID", SqlDbType.Date).Value =
                    model.AluguelID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Inserir(FilmeAluguel model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO FilmeAluguel (" +
                    "FilmeID," +
                    "ValorFilme," +
                    "QTD," +
                    "AluguelID) " +
                    "VALUES(" +
                    "@FilmeID," +
                    "@ValorFilme," +
                    "@QTD," +
                    "@AluguelID)";

                cmd.Parameters.Add("@FilmeID", SqlDbType.Date).Value =
                    model.FilmeID;
                cmd.Parameters.Add("@ValorFilme", SqlDbType.Date).Value =
                    model.ValorFilme;
                cmd.Parameters.Add("@QTD", SqlDbType.Date).Value =
                    model.QTD;
                cmd.Parameters.Add("@AluguelID", SqlDbType.Date).Value =
                    model.AluguelID;

                cmd.ExecuteNonQuery();
            }
        }

        public Collection<FilmeAluguel> ListarTudo()//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "FilmeID," +
                    "ValorFilme," +
                    "QTD," +
                    "AluguelID " +
                    "FROM FilmeAluguel " +
                    "ORDER BY ID";

                using (adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tblFilmeAluguel);

                    foreach (DataRow row in tblFilmeAluguel.Rows)
                    {
                        FilmeAluguel = new FilmeAluguel
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            FilmeID = int.Parse(row["FilmeID"].ToString()),
                            ValorFilme = Decimal.Parse(row["ValorFilme"].ToString()),
                            QTD = int.Parse(row["QTD"].ToString()),
                            AluguelID = int.Parse(row["AluguelID"].ToString())
                        };
                        FilmesAluguel.Add(FilmeAluguel);
                    }
                }
            }

            return FilmesAluguel;
        }

        public FilmeAluguel LocalizarPorCodigo(params object[] keys)
        {
            FilmeAluguel = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "FilmeID," +
                    "ValorFilme," +
                    "QTD," +
                    "AluguelID " +
                    "FROM FilmeAluguel " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    keys[0];

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        FilmeAluguel = new FilmeAluguel();
                        reader.Read();
                        FilmeAluguel.ID = reader.GetInt32(0);
                        FilmeAluguel.FilmeID = reader.GetInt32(1);
                        FilmeAluguel.ValorFilme = reader.GetDecimal(2);
                        FilmeAluguel.QTD = reader.GetInt32(3);
                        FilmeAluguel.AluguelID = reader.GetInt32(4);
                    }
                }
            }

            return FilmeAluguel;
        }

        public FilmeAluguel LocalizarPrimeiro()
        {
            FilmeAluguel = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT TOP 1 " +
                    "ID," +
                    "FilmeID," +
                    "ValorFilme," +
                    "QTD," +
                    "AluguelID " +
                    "FROM FilmeAluguel";

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        FilmeAluguel = new FilmeAluguel();
                        reader.Read();
                        FilmeAluguel.ID = reader.GetInt32(0);
                        FilmeAluguel.FilmeID = reader.GetInt32(1);
                        FilmeAluguel.ValorFilme = reader.GetDecimal(2);
                        FilmeAluguel.QTD = reader.GetInt32(3);
                        FilmeAluguel.AluguelID = reader.GetInt32(4);
                    }
                }
            }

            return FilmeAluguel;
        }

        public void Remover(FilmeAluguel model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "DELETE FROM FilmeAluguel WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
