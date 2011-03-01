using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Infraestrutura
{
    public interface IStartupTask
    {
        void Execute();
    }
}