using System;
using TeAjudo.Models.Principal.Repositorios;
using TeAjudo.Models.Principal.Servicos;

namespace TeAjudo.Models.Infraestrutura.Servicos
{
    public class ServicoAutorizacao : IServicoAutorizacao
    {
        private readonly IUsuarioRepositorio repositorioUsuario;

        public ServicoAutorizacao(IUsuarioRepositorio repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public bool ValidarUsuario(string login, string senha)
        {
            var usuario = repositorioUsuario.ObterPorLogin(login);
            return usuario != null && usuario.Senha == senha;
        }

        public void AlterarSenha(string login, string senhaAtual, string novaSenha)
        {
            var usuario = repositorioUsuario.ObterPorLogin(login);

            ValidarNovaSenha(senhaAtual, novaSenha);

            usuario.Senha = novaSenha;

            repositorioUsuario.Salvar(usuario);
        }

        private void ValidarNovaSenha(string senhaAtual, string novaSenha)
        {
            if (senhaAtual != novaSenha)
                throw new ApplicationException("A nova senha não pode ser igual a senha atual.");
        }
    }
}