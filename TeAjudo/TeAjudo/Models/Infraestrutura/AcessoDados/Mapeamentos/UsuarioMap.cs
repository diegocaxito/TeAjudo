using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeAjudo.Models.Principal.Modelos;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Mapeamentos
{
    public class UsuarioMap : EntidadeMap<Usuario>
    {
        public UsuarioMap()
        {
            Map(x => x.Email).Unique();
            Map(x => x.Nome);
            Map(x => x.Senha);
            Map(x => x.TipoUsuario).CustomType(typeof(TipoUsuario));
        }
    }
}