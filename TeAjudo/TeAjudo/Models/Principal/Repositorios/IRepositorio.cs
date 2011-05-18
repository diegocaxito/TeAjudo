using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace TeAjudo.Models.Principal.Repositorios
{
    public interface IRepositorio<T> where T : class 
    {
        T PegarPeloId(Guid id);
        void Salvar(T entity);
        IEnumerable<T> ListarTodos();
        void Remover(T entity);
        INHibernateQueryable<T> Query();
        IQueryable<T> Query(Expression<Func<T, bool>> filtro);
    }
}
