using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using TeAjudo.Models.Principal.Modelos;
using NHibernate.ByteCode.Castle;
using System.Reflection;
using System.Data;

namespace TeAjudo.Models.Infraestrutura.AcessoDados
{
    public class NHibernateSessionSource : ISessionSource
    {
        private readonly object factorySyncRoot = new object();
        private readonly ISessionFactory sessionFactory;
        private readonly Configuration configuration;

        public NHibernateSessionSource() {
            if (sessionFactory != null) return;

            lock (factorySyncRoot) {
                if (sessionFactory != null) return;
                configuration = AssembleConfiguration();
                sessionFactory = configuration.BuildSessionFactory();
            }
        }

        private Configuration AssembleConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2008
                        .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionTeAjudo"))
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
            ISession session = CreateSession();
            IDbConnection connection = session.Connection;
            Dialect dialect = Dialect.GetDialect(configuration.Properties);
            string[] drops = configuration.GenerateDropSchemaScript(dialect);
            ExecuteScripts(drops, connection);

            string[] scripts = configuration.GenerateSchemaCreationScript(dialect);
            ExecuteScripts(scripts, connection);
        }

        private static void ExecuteScripts(IEnumerable<string> scripts, IDbConnection connection)
        {
            foreach (string script in scripts)
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = script;
                command.ExecuteNonQuery();
            }
        }
    }
}