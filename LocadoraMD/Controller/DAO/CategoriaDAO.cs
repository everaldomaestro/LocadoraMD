using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.ObjectModel;
using Contratos.Connect;
using System.Data.SqlClient;
using System.Data;

namespace Controller.DAO
{
    public class CategoriaDAO : IDAO<Categoria>
    {
        private IConnection _connection;
        SqlCommand cmd;
        Collection<Categoria> Categorias = new Collection<Categoria>();
        Categoria Categoria;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable tblCategoria = new DataTable();

        public CategoriaDAO(IConnection Connection)
        {
            _connection = Connection;
        }

        public void Atualizar(Categoria model)//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE Categoria SET " +
                    "Descricao=@Descricao " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value =
                    model.Descricao;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Inserir(Categoria model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "INSERT INTO Categoria (" +
                    "Descricao) " +
                    "VALUES(" +
                    "@Descricao)";

                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value =
                    model.Descricao;

                cmd.ExecuteNonQuery();
            }
        }

        public Collection<Categoria> ListarTudo()//OK
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "Descricao " +
                    "FROM Categoria " +
                    "ORDER BY Descricao";

                using (adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tblCategoria);

                    foreach (DataRow row in tblCategoria.Rows)
                    {
                        Categoria = new Categoria
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Descricao = row["Descricao"].ToString()
                        };
                        Categorias.Add(Categoria);
                    }
                }
            }

            return Categorias;
        }

        public Categoria LocalizarPorCodigo(params object[] keys)
        {
            Categoria = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT " +
                    "ID," +
                    "Descricao " +
                    "FROM Categoria " +
                    "WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    keys[0];

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Categoria = new Categoria();
                        reader.Read();
                        Categoria.ID = reader.GetInt32(0);
                        Categoria.Descricao = reader.GetString(1);
                    }
                }
            }

            return Categoria;
        }

        public Categoria LocalizarPrimeiro()
        {
            Categoria = null;

            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "SELECT TOP 1 " +
                    "ID," +
                    "Descricao " +
                    "FROM Categoria";

                using (reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Categoria = new Categoria();
                        reader.Read();
                        Categoria.ID = reader.GetInt32(0);
                        Categoria.Descricao = reader.GetString(1);
                    }
                }
            }

            return Categoria;
        }

        public void Remover(Categoria model)
        {
            using (cmd = _connection.Buscar().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "DELETE FROM Categoria WHERE ID=@ID";

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =
                    model.ID;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
