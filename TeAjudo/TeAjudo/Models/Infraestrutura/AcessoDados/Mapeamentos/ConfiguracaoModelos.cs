using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Mapeamentos
{
    public class ConfiguracaoModelos : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "TeAjudo.Models.Principal.Modelos";
        }
    }
}