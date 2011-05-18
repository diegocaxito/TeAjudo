using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using TeAjudo.Models.Principal.Modelos;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Mapeamentos
{
    public abstract class EntidadeMap<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade
    {
        protected EntidadeMap()
        {
            Id(x => x.Id).Unique().GeneratedBy.Guid();
        }
    }
}