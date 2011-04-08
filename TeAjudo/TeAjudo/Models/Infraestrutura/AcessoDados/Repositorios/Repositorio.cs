using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TeAjudo.Models.Principal.Repositorios;
using NHibernate;
using NHibernate.Linq;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T>
        where T : class
    {
        private ISession session;
        protected Repositorio(ISession session) {
            this.session = session;
        }

        public T PegarPeloId(Guid id) {
            return session.Get<T>(id);
        }

        public void Salvar(T entidade) {
            session.Save(entidade);
        }

        public IEnumerable<T> ListarTodos() {
            var criteria = session.CreateCriteria<T>();
            return criteria.List<T>();
        }

        public void Remover(T entidade) {
            session.Delete(entidade);
        }

        public INHibernateQueryable<T> Query()
        {
            return session.Linq<T>();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filtro)
        {
            return Query().Where(filtro);
        }
    }
}