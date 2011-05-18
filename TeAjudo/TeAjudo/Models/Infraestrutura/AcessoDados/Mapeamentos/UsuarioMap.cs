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
            Map(x => x.Login).Length(20).Unique();
            Map(x => x.Nome).Length(100);
            Map(x => x.Senha).Length(50);
            Map(x => x.TipoUsuario).CustomType(typeof(TipoUsuario));
        }
    }
}