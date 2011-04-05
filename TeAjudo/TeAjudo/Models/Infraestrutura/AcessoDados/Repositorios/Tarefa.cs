using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios
{
    public class Tarefa : Repositorio<Models.Principal.Modelos.Tarefa>, Models.Principal.Repositorios.ITarefa
    {
        public Tarefa(ISession session) : base(session) { }

        public void Solicitar(Principal.Modelos.Tarefa tarefa)
        {
            base.Salvar(tarefa);
        }        
    }
}