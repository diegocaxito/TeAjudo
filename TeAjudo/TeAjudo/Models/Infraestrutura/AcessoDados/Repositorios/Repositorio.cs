using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeAjudo.Models.Principal.Modelos;
using TeAjudo.Models.Principal.Repositorios;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T>
        where T : Entidade
    {
        protected Repositorio(ISession session) {
            Session = session;
        }

        protected ISession Session { get; private set; }

        public T PegarPeloId(Guid id) {
            return Session.Get<T>(id);
        }

        public void Salvar(T entidade) {
            Session.Save(entidade);
        }

        public IEnumerable<T> ListarTodos() {
            var criteria = Session.CreateCriteria<T>();
            return criteria.List<T>();
        }

        public void Remover(T entidade) {
            Session.Delete(entidade);
        }
    }
}