using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Infraestrutura.AcessoDados
{
    public class NHibernateConfiguration : IStartupTask
    {
        private readonly ISessionSource sessionSource;

        public NHibernateConfiguration(ISessionSource sessionSource) {
            this.sessionSource = sessionSource;
        }

        public void Execute()
        {
            sessionSource.BuildSchema();
        }
    }
}