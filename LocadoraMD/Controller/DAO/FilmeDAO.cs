using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.ObjectModel;
using Contratos.Connect;
using System.Data.SqlClient;
using System.Data;

namespace Controller.DAO
{
    public class FilmeDAO : IDAO<Filme>
    {
        private IConnection _connection;
        SqlCommand cmd;
        Collection<Filme> Filmes = new Collection<Filme>();
        Filme Filme;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable tblFilme = new DataTable();

        public FilmeDAO(IConnection Connection)
        {
            _connection = Connection;
        }

        public void Atualizar(Filme model)//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE Filme SET " +
                    "Titulo=@Titulo," +
                    "QTD=@QTD," +
                    "ValorAluguel=@ValorAluguel," +
                    "CategoriaID=@CategoriaID " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value =
                    model.Titulo;
                cmd.Parameters.Add("@QTD", SqlDbType.Int).Value =
                    model.QTD;
                cmd.Parameters.Add("@ValorAluguel", SqlDbType.Decimal).Value =
                    model.ValorAluguel;
                cmd.Parameters.Add("@CategoriaID", SqlDbType.Int).Value =
                    model.CategoriaID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Inserir(Filme model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO Filme (" +
                    "Titulo," +
                    "QTD," +
                    "ValorAluguel," +
                    "CategoriaID) " +
                    "VALUES(" +
                    "@Titulo," +
                    "@QTD," +
                    "@ValorAluguel," +
                    "@CategoriaID)";

                cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value =
                    model.Titulo;
                cmd.Parameters.Add("@QTD", SqlDbType.Int).Value =
                    model.QTD;
                cmd.Parameters.Add("@ValorAluguel", SqlDbType.Decimal).Value =
                    model.ValorAluguel;
                cmd.Parameters.Add("@CategoriaID", SqlDbType.Int).Value =
                    model.CategoriaID;

                cmd.ExecuteNonQuery();
            }
        }

        public Collection<Filme> ListarTudo()//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "Titulo," +
                    "QTD," +
                    "ValorAluguel," +
                    "CategoriaID " +
                    "FROM Filme " +
                    "ORDER BY ID";

                using (adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tblFilme);

                    foreach (DataRow row in tblFilme.Rows)
                    {
                        Filme = new Filme
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Titulo = row["Titulo"].ToString(),
                            QTD = int.Parse(row["QTD"].ToString()),
                            ValorAluguel = Decimal.Parse(row["ValorAluguel"].ToString()),
                            CategoriaID = int.Parse(row["CategoriaID"].ToString())
                        };
                        Filmes.Add(Filme);
                    }
                }
            }

            return Filmes;
        }

        public Filme LocalizarPorCodigo(params object[] keys)
        {
            Filme = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "Titulo," +
                    "QTD," +
                    "ValorAluguel," +
                    "CategoriaID " +
                    "FROM Filme " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    keys[0];

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Filme = new Filme();
                        reader.Read();
                        Filme.ID = reader.GetInt32(0);
                        Filme.Titulo = reader.GetString(1);
                        Filme.QTD = reader.GetInt32(2);
                        Filme.ValorAluguel = reader.GetDecimal(3);
                        Filme.CategoriaID = reader.GetInt32(4);
                    }
                }
            }

            return Filme;
        }

        public Filme LocalizarPrimeiro()
        {
            Filme = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT TOP 1 " +
                    "ID," +
                    "Titulo," +
                    "QTD," +
                    "ValorAluguel," +
                    "CategoriaID " +
                    "FROM Filme";

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Filme = new Filme();
                        reader.Read();
                        Filme.ID = reader.GetInt32(0);
                        Filme.Titulo = reader.GetString(1);
                        Filme.QTD = reader.GetInt32(2);
                        Filme.ValorAluguel = reader.GetDecimal(3);
                        Filme.CategoriaID = reader.GetInt32(4);
                    }
                }
            }

            return Filme;
        }

        public void Remover(Filme model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "DELETE FROM Filme WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
