using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Principal.Modelos.Usuario>, Principal.Repositorios.IUsuarioRepositorio
    {
        public UsuarioRepositorio(ISession session) : base(session)
        {
        }

        public Principal.Modelos.Usuario ObterPorLogin(string login)
        {
            return session.QueryOver<Principal.Modelos.Usuario>().And(c => c.Login == login).SingleOrDefault();
        }
    }
}