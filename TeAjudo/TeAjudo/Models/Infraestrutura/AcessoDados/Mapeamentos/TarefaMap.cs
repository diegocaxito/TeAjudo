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
            Map(x => x.Titulo);
            Map(x => x.Descricao);
            References(x => x.Usuario);
        }
    }
}