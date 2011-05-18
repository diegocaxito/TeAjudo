using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace TeAjudo.Models.Infraestrutura.Testes
{
    [TestFixture]
    public class UsuarioRepositorioTeste : InfraestruturaTesteBase
    {
        [Test]
        public void Salvar_UmUsuario_SalvarNoBanco()
        {
            var sessao = SessionBuilder.CreateSession();
            var repositorio =
                new Models.Infraestrutura.AcessoDados.Repositorios.UsuarioRepositorio(sessao);
            var usuario = new Models.Principal.Modelos.Usuario
                              {
                                  Login = "diego",
                                  Senha = "senha",
                                  Nome = "Diego",
                                  TipoUsuario = Models.Principal.Modelos.TipoUsuario.Administrador
                              };
            using (var t = sessao.BeginTransaction())
            {
                repositorio.Salvar(usuario);
                t.Commit();
            }
        }
    }
}