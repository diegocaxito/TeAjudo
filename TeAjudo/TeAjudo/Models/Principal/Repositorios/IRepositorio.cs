using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeAjudo.Models.Principal.Modelos;
using NHibernate.Linq;
using System.Linq;

namespace TeAjudo.Models.Principal.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        T PegarPeloId(Guid id);
        void Salvar(T entity);
        IEnumerable<T> ListarTodos();
        void Remover(T entity);
    }
}
