using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using StructureMap;
using TeAjudo.Models.Principal.Repositorios;

namespace TeAjudo.Models.Infraestrutura.Testes.IoC
{
    [TestFixture]
    public class DependencyResolverTests //: InfraestruturaTesteBase
    {
        [Test]
        public void VerificarConteinerDeInjecaoDependencia()
        {   
            ObjectFactory.AssertConfigurationIsValid();
        }
    }
    
}