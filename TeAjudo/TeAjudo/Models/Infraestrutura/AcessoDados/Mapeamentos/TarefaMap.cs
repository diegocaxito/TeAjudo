using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeAjudo.Models.Principal.Modelos;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.Mapeamentos
{
    public class TarefaMap : EntidadeMap<Tarefa>
    {
        public TarefaMap()
        {   
            Map(x => x.Assunto);
            Map(x => x.Descricao);
            Map(x => x.OrigemSolicitacao).CustomType(typeof(OrigemSolicitacao));
            References(x => x.Usuario);
            References(x => x.Atendente);
        }
    }
}