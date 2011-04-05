using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeAjudo.Models.Principal.Servicos
{
    public class SolicitarTarefa
    {
        private Repositorios.ITarefa repositorio;

        public SolicitarTarefa(Repositorios.ITarefa repositorio)
        {   
            this.repositorio = repositorio;
        }

        public void Solicitar(Modelos.Tarefa tarefa)
        {
            tarefa.ValidarTitulo();
            repositorio.Solicitar(tarefa);
        }
    }
}