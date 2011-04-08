using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration
{
    public interface ISessionBuilder
    {
        ISession CreateSession();
        void BuildSchema();
    }

    public class SessionBuilder : ISessionBuilder
    {
        private readonly IConnectionString connectionString;
        private readonly object factorySyncRoot = new object();
        private readonly ISessionFactory sessionFactory;
        private readonly Configuration configuration;

        public SessionBuilder(IConnectionString connectionString)
        {
            this.connectionString = connectionString;
            if(sessionFactory!=null) return;
            lock (factorySyncRoot)
            {
                if(sessionFactory!=null) return;
                configuration = AssemblyConfiguration();
                sessionFactory = configuration.BuildSessionFactory();
            }
        }

        private Configuration AssemblyConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2008
                        .ConnectionString(connectionString.Get())
                        .DefaultSchema("TeAjudo")
                        .DoNot.ShowSql()
                        .AdoNetBatchSize(100)
                        .ProxyFactoryFactory(typeof(ProxyFactoryFactory)))
                .Mappings(cfg => cfg.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildConfiguration();
        }

        public ISession CreateSession()
        {
            return sessionFactory.OpenSession();
        }

        public void BuildSchema()
        {
            new SchemaExport(configuration).Execute(false, true, false);
        }
    }
}