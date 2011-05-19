using System;
using System.Web.Mvc;
using TeAjudo.Apresentacao.Modelos;
using TeAjudo.Models.Principal.Modelos;
using TeAjudo.Models.Principal.Repositorios;
using TeAjudo.Apresentacao.Atributos;
using AutoMapper;
using TeAjudo.Models.Principal.Servicos;
using System.Linq;

namespace TeAjudo.Controllers
{
    //[AutoMap]
    public class TarefaController : BaseController
    {
        private readonly ITarefaRepositorio repositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;
        //private readonly IServicoAutorizacao servicoAutorizacao;

        public TarefaController(ITarefaRepositorio repositorioTarefa, IUsuarioRepositorio usuarioRepositorio)
        {
            repositorio = repositorioTarefa;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        //[AutoMap(typeof(Apresentacao.Modelos.Tafera), typeof(Models.Principal.Modelos.Tarefa))]
        public ActionResult Solicitar(Apresentacao.Modelos.Tafera modelo) {
            if (ModelState.IsValid)
            {
                var tarefa = new TeAjudo.Models.Principal.Modelos.Tarefa(repositorio);
                Mapper.CreateMap<Apresentacao.Modelos.Tafera, Models.Principal.Modelos.Tarefa>();
                Mapper.Map(modelo, tarefa);
                tarefa.Usuario = usuarioRepositorio.ObterPorLogin(User.Identity.Name);
                tarefa.Solicitar();
                return View("Sucesso");
            }
            return View();
        }

        [HttpGet]
        [AutoMap(typeof(TeAjudo.Models.Principal.Modelos.Tarefa) ,typeof(Apresentacao.Modelos.Tafera))]
        public ActionResult Solicitar()
        {
            var tarefa = new Tarefa(repositorio);
            return View(tarefa);
        }

        public ActionResult Sucesso() {
            return View();
        }

        [HttpGet]
        public ActionResult SolicitarAtendente()
        {
            var tarefa = new Apresentacao.Modelos.Tafera();
            tarefa.Origem = new SelectList((from OrigemSolicitacao o in Enum.GetValues(typeof(Models.Principal.Modelos.OrigemSolicitacao))
                                            select new { Id = o, Name = o.ToString() }));
                
            return View(tarefa);
        }

    }
}
