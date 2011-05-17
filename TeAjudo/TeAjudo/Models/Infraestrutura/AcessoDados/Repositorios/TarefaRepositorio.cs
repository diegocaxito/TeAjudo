using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public class TarefaRepositorio : Repositorio<Principal.Modelos.Tarefa>, Principal.Repositorios.ITarefaRepositorio
    {
        public TarefaRepositorio(ISession session) : base(session) { }

        public void Solicitar(Principal.Modelos.Tarefa tarefa)
        {
            Salvar(tarefa);
        }        
    }
}