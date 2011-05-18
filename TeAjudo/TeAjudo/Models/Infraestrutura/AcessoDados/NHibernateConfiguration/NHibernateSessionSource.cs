using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Castle;
using System.Reflection;

//using System.Configuration;
//using System.Web.Configuration;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration
{
    public class NHibernateSessionSource
    {
        private readonly object factorySyncRoot = new object();        
        private readonly IConnectionString connectionString;

        public NHibernateSessionSource(IConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return GetFluentConfiguration()
                .BuildSessionFactory();
        }

        public FluentConfiguration GetFluentConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2008
                        .ConnectionString(connectionString.Get())
                        .DefaultSchema("TeAjudo")
                        .DoNot.ShowSql()
                        .AdoNetBatchSize(100)
                        .ProxyFactoryFactory(typeof (ProxyFactoryFactory)))
                .Mappings(cfg => cfg.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }

    public interface IConnectionString
    {
        string Get();
    }

    public class TesteConnectionString : IConnectionString
    {
        public string Get()
        {
            return @"Persist Security Info=False;User ID=TeAjudo;Initial Catalog=TeAjudo;Data Source=localhost\SQLEXPRESS;Password=teajudo;";
        }
    }

    public class ConnectionString : IConnectionString
    {
        public string Get()
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TeAjudo"].ConnectionString;
        }
    }
}