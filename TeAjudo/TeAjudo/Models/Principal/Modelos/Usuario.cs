using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel;

namespace TeAjudo.Models.Principal.Modelos
{
    public class Usuario : Entidade
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }

    public enum TipoUsuario
    {   
        [Description("Usuário")]
        Usuario,
        [Description("Atendente")]
        Atendente,
        [Description("Gestor")]
        Gestor,
        [Description("Administrador")]
        Administrador
    }
}