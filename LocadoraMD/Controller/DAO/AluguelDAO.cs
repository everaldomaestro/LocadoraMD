using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.ObjectModel;
using Contratos.Connect;
using System.Data.SqlClient;
using System.Data;

namespace Controller.DAO
{
    public class AluguelDAO : IDAO<Aluguel>
    {
        private IConnection _connection;
        SqlCommand cmd;
        Collection<Aluguel> Alugueis = new Collection<Aluguel>();
        Aluguel Aluguel;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable tblAluguel = new DataTable();

        public AluguelDAO(IConnection Connection)
        {
            _connection = Connection;
        }

        public void Atualizar(Aluguel model)//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE Aluguel SET " +
                    "AluguelID=@AluguelID," +
                    "DataAluguel=@DataAluguel," +
                    "DataDevolucao=@DataDevolucao," +
                    "ValorAluguel=@ValorAluguel," +
                    "ClienteID=@ClienteID," +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@AluguelID", SqlDbType.Int).Value =
                    model.AluguelID;
                cmd.Parameters.Add("@DataAluguel", SqlDbType.Date).Value =
                    model.DataAluguel;
                cmd.Parameters.Add("@DataDevolucao", SqlDbType.Date).Value =
                    model.DataDevolucao;
                cmd.Parameters.Add("@ValorAluguel", SqlDbType.Decimal).Value =
                    model.ValorAluguel;
                cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value =
                    model.ClienteID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Inserir(Aluguel model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO Aluguel (" +
                    "AluguelID," +
                    "DataAluguel," +
                    "DataDevolucao," +
                    "ValorAluguel," +
                    "ClienteID) " +
                    "VALUES(" +
                    "@AluguelID," +
                    "@DataAluguel," +
                    "@DataDevolucao," +
                    "@ValorAluguel," +
                    "@ClienteID)";

                cmd.Parameters.Add("@AluguelID", SqlDbType.Int).Value =
                    model.AluguelID;
                cmd.Parameters.Add("@DataAluguel", SqlDbType.Date).Value =
                    model.DataAluguel;
                cmd.Parameters.Add("@DataDevolucao", SqlDbType.Date).Value =
                    model.DataDevolucao;
                cmd.Parameters.Add("@ValorAluguel", SqlDbType.Decimal).Value =
                    model.ValorAluguel;
                cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value =
                    model.ClienteID;

                cmd.ExecuteNonQuery();
            }
        }

        public Collection<Aluguel> ListarTudo()//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "AluguelID," +
                    "DataAluguel," +
                    "DataDevolucao," +
                    "ValorAluguel," +
                    "ClienteID " +
                    "FROM Aluguel " +
                    "ORDER BY AluguelID";

                using (adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tblAluguel);

                    foreach (DataRow row in tblAluguel.Rows)
                    {
                        Aluguel = new Aluguel
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            AluguelID = int.Parse(row["AluguelID"].ToString()),
                            DataAluguel = DateTime.Parse(row["DataAluguel"].ToString()),
                            DataDevolucao = DateTime.Parse(row["DataDevolucao"].ToString()),
                            ValorAluguel = Decimal.Parse(row["ValorAluguel"].ToString()),
                            ClienteID = int.Parse(row["ClienteID"].ToString())
                        };
                        Alugueis.Add(Aluguel);
                    }
                }
            }

            return Alugueis;
        }

        public Aluguel LocalizarPorCodigo(params object[] keys)
        {
            Aluguel = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "AluguelID," +
                    "DataAluguel," +
                    "DataDevolucao," +
                    "ValorAluguel," +
                    "ClienteID " +
                    "FROM Aluguel " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    keys[0];

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Aluguel = new Aluguel();
                        reader.Read();
                        Aluguel.ID = reader.GetInt32(0);
                        Aluguel.AluguelID = reader.GetInt32(1);
                        Aluguel.DataAluguel = reader.GetDateTime(2);
                        Aluguel.DataDevolucao = reader.GetDateTime(3);
                        Aluguel.ValorAluguel = reader.GetDecimal(4);
                        Aluguel.ClienteID = reader.GetInt32(5);
                    }
                }
            }

            return Aluguel;
        }

        public Aluguel LocalizarPrimeiro()
        {
            Aluguel = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT TOP 1 " +
                    "ID," +
                    "AluguelID," +
                    "DataAluguel," +
                    "DataDevolucao," +
                    "ValorAluguel," +
                    "ClienteID " +
                    "FROM Aluguel";

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Aluguel = new Aluguel();
                        reader.Read();
                        Aluguel.ID = reader.GetInt32(0);
                        Aluguel.AluguelID = reader.GetInt32(1);
                        Aluguel.DataAluguel = reader.GetDateTime(2);
                        Aluguel.DataDevolucao = reader.GetDateTime(3);
                        Aluguel.ValorAluguel = reader.GetDecimal(4);
                        Aluguel.ClienteID = reader.GetInt32(5);
                    }
                }
            }

            return Aluguel;
        }

        public void Remover(Aluguel model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "DELETE FROM Aluguel WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
