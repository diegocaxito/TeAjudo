namespace TeAjudo.Models.Principal.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Modelos.Usuario>
    {
        Modelos.Usuario ObterPorLogin(string login);
    }
}