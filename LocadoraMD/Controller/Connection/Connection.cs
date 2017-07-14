using Contratos.Connection;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Controller.Connection
{
    public class Connection : IConnection
    {
        private SqlConnection _connection;

        public Connection()
        {
            _connection = new SqlConnection(
                "Data Source = TI, 1433; " +
                "Initial Catalog = Locadora;" +
                "Integrated Security = True");
        }

        public SqlConnection Abrir()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public SqlConnection Buscar()
        {
            return Abrir();
        }

        public void Dispose()
        {
            Fechar();
            GC.SuppressFinalize(this);
        }

        public void Fechar()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
