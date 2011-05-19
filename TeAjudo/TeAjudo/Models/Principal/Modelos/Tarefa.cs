using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeAjudo.Models.Principal.Repositorios;

namespace TeAjudo.Models.Principal.Modelos
{
    public class Tarefa : Entidade
    {
        private Principal.Repositorios.ITarefaRepositorio repositorio;

        public Tarefa(ITarefaRepositorio repositorio) : this()
        {   
            this.repositorio = repositorio;
        }

        public Tarefa()
        {
            erros = new StringBuilder();
        }

        public virtual string Assunto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual OrigemSolicitacao OrigemSolicitacao { get; set; }
        public virtual Usuario Atendente { get; set; }

        private StringBuilder erros;

        public virtual void Solicitar()
        {
            ValidarSolicitacao();
            VerificarErros();
            repositorio.Solicitar(this);
        }

        private void ValidarSolicitacao()
        {
            ValidarInstanciaRepositorio();
            ValidarAssunto();
        }

        private void ValidarInstanciaRepositorio()
        {
            if (repositorio == null)
                erros.AppendLine("Instancie o repositorio de tarefas.");
        }

        public virtual void ValidarAssunto()
        {
            if (string.IsNullOrWhiteSpace(Assunto))
                erros.AppendLine("Assunto não pode ser vazio.");
        }

        private void VerificarErros()
        {
            if(erros.Length>0)
                throw new ApplicationException(erros.ToString());
        }

        public virtual void SolicitarPeloAtendente()
        {
            ValidarSolicitacao();
            ValidarAtendente();
            ValidarDescricao();
            VerificarErros();
            repositorio.Solicitar(this);
        }

        private void ValidarDescricao()
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                erros.AppendLine("Descrição não pode ser vazio.");
        }

        private void ValidarAtendente()
        {
            if(!(Atendente!=null && Atendente.Id != Guid.Empty))
                erros.AppendLine("Informe o atendente.");
        }
    }
}
