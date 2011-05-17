using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace TeAjudo.Models.Infraestrutura.Mapeamento
{
    public class ConfiguracaoAutoMapper
    {
        public static void Configurar()
        {
            Mapper.Initialize(x => x.AddProfile<PerfilMapeamentoPrincipal>());
        }
    }

    public class PerfilMapeamentoPrincipal : Profile
    {
        protected override void Configure()
        {
            CreateMap<Principal.Modelos.Tarefa, Apresentacao.Modelos.Tafera>();
        }
    }
}