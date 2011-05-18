using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Principal.Servicos
{
    public interface IServicoAutorizacao
    {
        bool ValidarUsuario(string login, string senha);
        void AlterarSenha(string login, string senhaAtual, string novaSenha);
    }
}