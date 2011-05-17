using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeAjudo.Models.Principal.Repositorios
{
    public interface ITarefaRepositorio
    {
        void Solicitar(Modelos.Tarefa tarefa);
    }
}
