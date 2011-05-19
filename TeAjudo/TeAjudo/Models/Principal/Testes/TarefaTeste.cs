using System;
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
            tarefa.Assunto = "teste";
            tarefa.Solicitar();
            repositorio.AssertWasCalled(r=>r.Solicitar(tarefa));
        }

        [Test, ExpectedException]
        public void Solicitar_PassarTarefaSemTitulo_NaoChamarRepositorio()
        {
            tarefa.Solicitar();
            repositorio.AssertWasNotCalled(r=>r.Solicitar(tarefa));
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void Solicitar_PassarRepositorioNulo_DispararExcecao()
        {
            var tarefaParaRealizar = new Tarefa(null);
            tarefaParaRealizar.Assunto = "assunto";
            tarefaParaRealizar.Solicitar();
        }

        [Test]
        public void SolicitarPeloAtendente_PassarTarefaCompleta_ChamarRepositorio()
        {
            IniciarTarefaValidaParaSolicitarPeloAtentende();
            tarefa.SolicitarPeloAtendente();
            repositorio.AssertWasCalled(r=>r.Solicitar(tarefa));
        }

        private void IniciarTarefaValidaParaSolicitarPeloAtentende()
        {
            tarefa.Atendente = new Usuario {Id = Guid.NewGuid(), Email = "diegocaxito@gmail.com"};
            tarefa.Assunto = "Assunto";
            tarefa.OrigemSolicitacao = OrigemSolicitacao.Telefone;
            tarefa.Descricao = "Descricao";
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void SolicitarPeloAtendente_SemAtendente_DispararExcecao()
        {
            IniciarTarefaValidaParaSolicitarPeloAtentende();

            tarefa.Atendente = null;

            tarefa.SolicitarPeloAtendente();

            repositorio.AssertWasNotCalled(r=>r.Solicitar(tarefa));
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void SolicitarPeloAtendente_SemAssunto_DispararExcecao()
        {
            IniciarTarefaValidaParaSolicitarPeloAtentende();

            tarefa.Assunto = string.Empty;

            tarefa.SolicitarPeloAtendente();
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void SolicitarPeloAtendente_SemDescricao_DispararExcecao()
        {
            IniciarTarefaValidaParaSolicitarPeloAtentende();

            tarefa.Descricao = string.Empty;

            tarefa.SolicitarPeloAtendente();
        }
    }
}