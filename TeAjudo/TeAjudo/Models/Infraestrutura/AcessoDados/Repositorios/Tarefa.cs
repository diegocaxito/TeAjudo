using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public class Tarefa : Repositorio<Principal.Modelos.Tarefa>, Principal.Repositorios.ITarefa
    {
        public Tarefa(ISession session) : base(session) { }

        public void Solicitar(Principal.Modelos.Tarefa tarefa)
        {
            Salvar(tarefa);
        }        
    }
}