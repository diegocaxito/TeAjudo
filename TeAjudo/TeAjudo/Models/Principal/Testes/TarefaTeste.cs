using NUnit.Framework;
using Rhino.Mocks;
using TeAjudo.Models.Principal.Modelos;

namespace TeAjudo.Models.Principal.Testes
{
    [TestFixture]
    public class TarefaTeste
    {
        private Principal.Repositorios.ITarefaRepositorio repositorio;
        private Principal.Modelos.Tarefa tarefa;

        [SetUp]
        public void Iniciar()
        {
            repositorio = MockRepository.GenerateMock<Principal.Repositorios.ITarefaRepositorio>();
            tarefa = new Tarefa(repositorio);
        }

        [Test]
        public void Solicitar_PassarTodosOsDados_ChamarRepositorio()
        {   
            tarefa.Titulo = "teste";
            tarefa.Solicitar();
            repositorio.AssertWasCalled(r=>r.Solicitar(tarefa));
        }

        [Test, ExpectedException]
        public void Solicitar_PassarTarefaSemTitulo_NaoChamarRepositorio()
        {
            tarefa.Solicitar();
            repositorio.AssertWasNotCalled(r=>r.Solicitar(tarefa));
        }
    }
}