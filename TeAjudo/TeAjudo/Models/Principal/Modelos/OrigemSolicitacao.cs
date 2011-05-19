using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TeAjudo.Models.Principal.Modelos
{
    public enum OrigemSolicitacao
    {
        [Description("Telefone")]
        Telefone,
        [Description("e-mail")]
        Email,
        [Description("Pessoalmente")]
        Pessoalmente,
        [Description("Outro")]
        Outro
    }
}
