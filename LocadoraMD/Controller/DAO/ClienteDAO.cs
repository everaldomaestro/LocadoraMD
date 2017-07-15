using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.ObjectModel;
using Contratos.Connect;
using System.Data.SqlClient;
using System.Data;

namespace Controller.DAO
{
    public class ClienteDAO : IDAO<Cliente>
    {
        private IConnection _connection;
        SqlCommand cmd;
        Collection<Cliente> Clientes = new Collection<Cliente>();
        Cliente Cliente;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable tblCliente = new DataTable();

        public ClienteDAO(IConnection Connection)
        {
            _connection = Connection;
        }

        public void Atualizar(Cliente model)//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE Cliente SET " +
                    "Nome=@Nome," +
                    "Sobrenome=@Sobrenome " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value =
                    model.Nome;
                cmd.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value =
                    model.Sobrenome;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Inserir(Cliente model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO Cliente (" +
                    "Nome, " +
                    "Sobrenome) " +
                    "VALUES(" +
                    "@Nome," +
                    "@Sobrenome)";

                cmd.Parameters.Add("@Nome", SqlDbType.Date).Value =
                    model.Nome;
                cmd.Parameters.Add("@Sobrenome", SqlDbType.Date).Value =
                    model.Sobrenome;

                cmd.ExecuteNonQuery();
            }
        }

        public Collection<Cliente> ListarTudo()//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "Nome," +
                    "Sobrenome," +
                    "Descricao " +
                    "FROM Cliente " +
                    "ORDER BY Nome";

                using (adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tblCliente);

                    foreach (DataRow row in tblCliente.Rows)
                    {
                        Cliente = new Cliente
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Nome = row["Nome"].ToString(),
                            Sobrenome = row["Sobrenome"].ToString()
                        };
                        Clientes.Add(Cliente);
                    }
                }
            }

            return Clientes;
        }

        public Cliente LocalizarPorCodigo(params object[] keys)
        {
            Cliente = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "Nome," +
                    "Sobrenome," +
                    "Descricao " +
                    "FROM Cliente " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    keys[0];

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Cliente = new Cliente();
                        reader.Read();
                        Cliente.ID = reader.GetInt32(0);
                        Cliente.Nome = reader.GetString(1);
                        Cliente.Sobrenome = reader.GetString(2);
                    }
                }
            }

            return Cliente;
        }

        public Cliente LocalizarPrimeiro()
        {
            Cliente = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT TOP 1 " +
                    "Nome," +
                    "Sobrenome," +
                    "Descricao " +
                    "FROM Cliente";

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Cliente = new Cliente();
                        reader.Read();
                        Cliente.ID = reader.GetInt32(0);
                        Cliente.Nome = reader.GetString(1);
                        Cliente.Sobrenome = reader.GetString(2);
                    }
                }
            }

            return Cliente;
        }

        public void Remover(Cliente model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "DELETE FROM Cliente WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;
            }
        }
    }
}
