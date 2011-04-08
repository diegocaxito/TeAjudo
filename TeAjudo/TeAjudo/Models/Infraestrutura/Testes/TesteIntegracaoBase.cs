using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using NHibernate;
using TeAjudo.Models.Infraestrutura.IoC;
using TeAjudo.Models.Principal.Modelos;
using StructureMap;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Castle;
using System.Data;
using NHibernate.Dialect;
using System.Reflection;
using TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration;

namespace TeAjudo.Models.Infraestrutura.Testes
{
    //[TestFixture]
    public abstract class InfraestruturaTesteBase
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            StructureMapBootstrapper.Initialize();

            ObjectFactory.EjectAllInstancesOf<IConnectionString>();

            ObjectFactory.Configure(x => x.For<IConnectionString>().Use<TesteConnectionString>());

            SessionBuilder = StructureMapBootstrapper.Resolve<ISessionBuilder>();
            UnitOfWork = StructureMapBootstrapper.Resolve<IUnitOfWork>();
        }

        [SetUp]
        public void BeforeEach()
        {
            //SessionBuilder.BuildSchema();
            UnitOfWork.Begin();
        }

        [TearDown]
        public void AfterEach()
        {
            UnitOfWork.Commit();
        }

        protected ISessionBuilder SessionBuilder { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        protected void SalvarEntidades(params Entidade[] entidades)
        {
            using (var session = SessionBuilder.CreateSession())
            using (var tx = session.BeginTransaction())
            {
                foreach (var entidade in entidades)
                    session.Save(entidade);

                tx.Commit();
            }
        }

    }
}