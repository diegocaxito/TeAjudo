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
            For<Principal.Repositorios.ITarefaRepositorio>().Use<AcessoDados.Repositorios.TarefaRepositorio>();
            For<Principal.Repositorios.IUsuarioRepositorio>().Use<AcessoDados.Repositorios.UsuarioRepositorio>();
        }
    }

    public class ServicosRegistry : Registry
    {
        public ServicosRegistry()
        {
            For<Principal.Servicos.IServicoAutorizacao>().Use<Infraestrutura.Servicos.ServicoAutorizacao>();
            For<Principal.Servicos.IServicoAutenticacao>().Use<Infraestrutura.Servicos.ServicoAutenticacao>();
        }
    }
}