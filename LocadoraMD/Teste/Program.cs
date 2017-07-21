using Controller.Controllers;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoriaController cc = new CategoriaController();
            Categoria c = new Categoria();
            Categoria c2 = cc.LocalizarPrimeiro();
            //{
            //    Descricao = "AVENTURAA"
            //};

            //cc.Inserir(c);


            //cat.Descricao = c.Descricao;

            //c = cc.LocalizarPorCodigo(;
            cc.Remover(c2);

            List<Categoria> cs = cc.ListarTudo().ToList();


            //Console.WriteLine("ID: {0}, Descrição: {1}", cat.ID, cat.Descricao);

            foreach (var i in cs)
            {
                Console.WriteLine("ID: {0}, Descrição: {1}", i.ID, i.Descricao);
            };

            Console.ReadKey();
        }
    }
}
