using System;
using System.Collections.ObjectModel;

namespace Contratos.Operation
{
    public interface IDAO<T>:IDisposable where T: class, new()
    {
        //Insert
        void Inserir(T model);
        //Update
        void Atualizar(T model);
        //Delete
        void Remover(T model);
        //Select All
        Collection<T> ListarTudo();
        //Select por ID
        T LocalizarPorCodigo(params Object[] keys);
        //Localizar o primeiro
        T LocalizarPrimeiro();
    }
}
