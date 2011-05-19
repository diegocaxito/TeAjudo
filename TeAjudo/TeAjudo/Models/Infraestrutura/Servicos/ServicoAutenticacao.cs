using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using TeAjudo.Models.Principal.Modelos;
using TeAjudo.Models.Principal.Repositorios;
using TeAjudo.Models.Principal.Servicos;
using TeAjudo.Models.Util;

namespace TeAjudo.Models.Infraestrutura.Servicos
{
    public class ServicoAutenticacao : IServicoAutenticacao
    {
        private IUsuarioRepositorio repositorioUsuario;

        public ServicoAutenticacao(IUsuarioRepositorio repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public void Autenticar(string login, bool gerarCookiePersistente)
        {
            var usuario = repositorioUsuario.ObterPorLogin(login);
            SetarCookieDeAutenticacao(gerarCookiePersistente, usuario);
        }

        private void SetarCookieDeAutenticacao(bool gerarCookiePersistente)
        {
            SetarCookieDeAutenticacao(gerarCookiePersistente, default(Usuario));
        }

        private void SetarCookieDeAutenticacao(bool gerarCookiePersistente, Usuario usuario)
        {
            var authTicket = CriarTicket(gerarCookiePersistente, usuario);
            CriarCookie(authTicket);
        }

        private FormsAuthenticationTicket CriarTicket(bool gerarCookiePersistente, Usuario usuario)
        {
            var grupo = usuario.TipoUsuario.PegarDescricao();
            return new FormsAuthenticationTicket(1, usuario.Email, DateTime.Now, DateTime.Now.AddMinutes(30), gerarCookiePersistente, grupo);
        }

        private void CriarCookie(FormsAuthenticationTicket authTicket)
        {
            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        public void Sair()
        {
            FormsAuthentication.SignOut();
        }
    }
}