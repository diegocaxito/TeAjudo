using System;
using System.Collections.Generic;

namespace TeAjudo.Models.Principal.Repositorios
{
    public interface IRepositorio<T> where T : class 
    {
        T PegarPeloId(Guid id);
        void Salvar(T entity);
        IEnumerable<T> ListarTodos();
        void Remover(T entity);
    }
}
