using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using FluentNHibernate.Testing;
using StructureMap;
using System.Web.Mvc;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.Testes.Mapeamento
{
    [TestFixture]
    public class TarefaMapeamento //: TesteIntegracaoBase
    {
        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            Infraestrutura.IoC.StructureMapBootstrapper.Initialize();
            AcessoDados.ISessionSource sessioSource = ObjectFactory.GetInstance<AcessoDados.ISessionSource>();
            sessioSource.BuildSchema();
        }

        protected AcessoDados.ISessionSource SessionSource { get; set; }

        [Test]
        public void PodeRelacionarMapeamento()
        {
            ISession session = SessionSource.CreateSession();
            new PersistenceSpecification<Models.Principal.Modelos.Tarefa>(session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Titulo, "Teste")
                .CheckProperty(c => c.Descricao, "Teste de descrição")
                .VerifyTheMappings();
        }
    }
}