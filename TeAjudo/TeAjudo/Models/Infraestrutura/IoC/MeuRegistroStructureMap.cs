using StructureMap.Configuration.DSL;
using NHibernate;
using TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration;

namespace TeAjudo.Models.Infraestrutura.IoC
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry() {
            For<IConnectionString>().Use<ConnectionString>();

            ForSingletonOf<ISessionBuilder>().Use<SessionBuilder>();

            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();

            For<ISession>().Use(c =>
                {
                    var sessionSource = c.GetInstance<IUnitOfWork>();
                    return sessionSource.CurrentSession;
                });
        }
    }

    public class RepositoriosRegistry : Registry
    {
        public RepositoriosRegistry()
        {
            For<Principal.Repositorios.ITarefa>().Use<AcessoDados.Repositorios.Tarefa>();
        }
    }
}