using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using FluentNHibernate.Testing;
using StructureMap;
using System.Web.Mvc;
using NHibernate;
using TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration;

namespace TeAjudo.Models.Infraestrutura.Testes.Mapeamento
{
    [TestFixture]
    public class TarefaMapTeste : InfraestruturaTesteBase
    {   
        [Test]
        public void PodeRelacionarMapeamento()
        {
            new PersistenceSpecification<Principal.Modelos.Tarefa>(SessionBuilder.CreateSession())
                .CheckProperty(c => c.Assunto, "Teste")
                .CheckProperty(c => c.Descricao, "Teste de descrição")
                .VerifyTheMappings();
        }
    }
}