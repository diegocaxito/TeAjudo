using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using StructureMap;
using TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration;

namespace TeAjudo.Models.Infraestrutura.Testes
{
    [TestFixture]
    public class MapeamentoTeste : InfraestruturaTesteBase
    {
        [Test]
        public void GerarEsquema_GerarEsquemaMapeamento_EsquemaGerado()
        {
            NHibernateSessionSource manageSession = GetManageSession();
            manageSession.GetFluentConfiguration().ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false)).BuildSessionFactory();
        }

        private NHibernateSessionSource GetManageSession()
        {
            var conexao = ObjectFactory.GetInstance(typeof(IConnectionString));
            return new NHibernateSessionSource((IConnectionString)conexao);
        }

        [Test]
        public void AtualizarEsquema_DestruirEsquemaExistenteCriarNovoEsquema_AtualizarEsquemaBancoDados()
        {
            var sessao = GetManageSession();
            sessao.GetFluentConfiguration().ExposeConfiguration(c => new SchemaUpdate(c).Execute(true, true)).
                BuildSessionFactory();
        }
    }
}