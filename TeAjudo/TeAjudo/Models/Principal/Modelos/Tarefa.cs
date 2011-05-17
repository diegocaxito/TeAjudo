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

        public Tarefa(ITarefaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Tarefa()
        {
        }

        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }

        public virtual void ValidarTitulo()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                throw new SemTituloException();
        }

        internal class SemTituloException : ApplicationException
        {
            public SemTituloException() : base("Informe o título da tarefa.") { }
        }

        public virtual void Solicitar()
        {
            this.ValidarTitulo();
            repositorio.Solicitar(this);
        }
    }
}
