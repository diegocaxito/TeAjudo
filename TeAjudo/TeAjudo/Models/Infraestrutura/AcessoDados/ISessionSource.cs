using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados
{
    public interface ISessionSource
    {
        ISession CreateSession();
        void BuildSchema();
    }
}
