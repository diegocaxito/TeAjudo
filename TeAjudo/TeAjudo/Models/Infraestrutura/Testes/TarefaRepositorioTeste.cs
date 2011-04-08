using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace TeAjudo.Models.Infraestrutura.Testes
{
    [TestFixture]
    public class TarefaRepositorioTeste : InfraestruturaTesteBase
    {
        [Test]
        public void Quando_entrar_dados_tarefa_e_chamar_salvar_dados_devem_ser_salvos_no_banco_de_dados()
        {
            var tarefa = new Principal.Modelos.Tarefa
                             {Titulo = "Novo Teste", Descricao = DateTime.Now.ToString()};
            var repositorioTarefa = new AcessoDados.Repositorios.Tarefa(SessionBuilder.CreateSession());
            var servico = new Principal.Servicos.SolicitarTarefa(repositorioTarefa);
            SalvarEntidades(tarefa);
        }
    }
}