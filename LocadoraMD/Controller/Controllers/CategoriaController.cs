using Contratos.Operation;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Controller.DAO;
using Controller.Connect;

namespace Controller.Controllers
{
    public class CategoriaController : IDAO<Categoria>
    {
        Connection con;
        IDAO<Categoria> TableIDAO;
        Categoria Categoria;
        Collection<Categoria> Categorias;

        public void Atualizar(Categoria model)
        {
            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categoria = new Categoria()
                {
                    ID = model.ID,
                    Descricao = model.Descricao
                };

                TableIDAO.Atualizar(Categoria);
            }

        }

        public void Dispose()
        {
            TableIDAO.Dispose();
        }

        public void Inserir(Categoria model)
        {
            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categoria = new Categoria()
                {
                    Descricao = model.Descricao
                };

                TableIDAO.Inserir(Categoria);
            }
        }

        public Collection<Categoria> ListarTudo()
        {
            Categorias = null;

            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categorias = TableIDAO.ListarTudo();
            }

            return Categorias;
        }

        public Categoria LocalizarPorCodigo(params object[] keys)
        {
            Categoria = null;

            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categoria = TableIDAO.LocalizarPorCodigo(keys);
            }

            return Categoria;
        }

        public Categoria LocalizarPrimeiro()
        {
            Categoria = null;

            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categoria = TableIDAO.LocalizarPrimeiro();
            }

            return Categoria;
        }

        public void Remover(Categoria model)
        {
            using (con = new Connection())
            {
                con.Abrir();
                TableIDAO = new CategoriaDAO(con);

                Categoria = new Categoria()
                {
                    ID = model.ID
                };

                TableIDAO.Remover(Categoria);
            }
        }
    }
}
