using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace TeAjudo.Models.Principal.Servicos
{
    public interface IServicoAutenticacao
    {
        void Autenticar(string login, bool gerarCookiePersistente);
        void Sair();
    }
}