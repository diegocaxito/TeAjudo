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
//using System.Configuration;
//using System.Web.Configuration;

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

        private NHibernate.Cfg.Configuration AssembleConfiguration()
        {
            // Get the connectionStrings section.
            System.Configuration.ConnectionStringsSection connectionStringsSection =
                System.Web.Configuration.WebConfigurationManager.GetSection("connectionStrings")
                as System.Configuration.ConnectionStringsSection;

            // Get the connectionStrings key,value pairs collection.
            System.Configuration.ConnectionStringSettingsCollection connectionStrings =
                connectionStringsSection.ConnectionStrings;
            string conexao = connectionStrings["TeAjudo"].ConnectionString;
            
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                        .MsSql2008                        
                        //.ConnectionString(@"Persist Security Info=False;User ID=TeAjudo;Initial Catalog=TeAjudo;Data Source=localhost\SQLEXPRESS;Password=teajudo;")
                        .ConnectionString(conexao)
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