using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeAjudo.Models.Principal.Modelos
{
    public class Tarefa : Entidade
    {
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
    }

    
}
