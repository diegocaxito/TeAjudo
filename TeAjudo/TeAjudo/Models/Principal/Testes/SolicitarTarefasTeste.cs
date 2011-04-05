using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Rhino.Mocks;

namespace TeAjudo.Models.Principal.Testes
{
    [TestFixture]
    public class SolicitarTarefas
    {
        Principal.Repositorios.ITarefa repositorio;
        Servicos.SolicitarTarefa servico;
        Modelos.Tarefa tarefa;

        [SetUp]
        public void Iniciar() {
            repositorio = MockRepository.GenerateMock<Principal.Repositorios.ITarefa>();
            servico = new Models.Principal.Servicos.SolicitarTarefa(repositorio);
            tarefa = new Principal.Modelos.Tarefa { Titulo = "Primeira Solicitação", Descricao = "Solicitacao Teste" };
        }

        [Test]
        public void Solicitar_SolicitarTarefacComumPeloCliente_SalvarSolicitacao() {
            servico.Solicitar(tarefa);
            repositorio.AssertWasCalled(r => r.Solicitar(tarefa));                       
        }

        [Test]
        [ExpectedException(ExpectedException=typeof(Modelos.Tarefa.SemTituloException), ExpectedMessage="Informe o título da tarefa.")]
        public void Solicitar_SolicitarSemTitulo_DispararExcecao() {
            tarefa.Titulo = string.Empty;
            servico.Solicitar(tarefa);
            repositorio.AssertWasNotCalled(r => r.Solicitar(tarefa));
        }
    }
}