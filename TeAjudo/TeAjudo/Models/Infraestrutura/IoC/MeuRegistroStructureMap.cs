using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration;
using StructureMap.Configuration.DSL;
using TeAjudo.Models.Infraestrutura.AcessoDados;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.IoC
{
    public class NHibernateStructureMap : Registry
    {
        public NHibernateStructureMap() {
            ForSingletonOf<ISessionSource>().Use<NHibernateSessionSource>();

            For<ISession>().Use(c => {
                var transaction = (NHibernateTransactionBoundary)c.GetInstance<ITransactionBoundary>();
                return transaction.CurrentSession;
            });

            For<ITransactionBoundary>().HybridHttpOrThreadLocalScoped().Use<NHibernateTransactionBoundary>();
        }
    }

    public class RepositoriosStructureMap : Registry {
        public RepositoriosStructureMap() {
            For<Principal.Repositorios.ITarefa>().Use<Infraestrutura.AcessoDados.Repositorios.Tarefa>();
        }
    }

    public class PrincipalRegistry : Registry { 
        //verificar principal registry
    }
}