using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeAjudo.Models.Infraestrutura.AcessoDados.Repositorios;
using TeAjudo.Models.Principal.Repositorios;
using TeAjudo.Models.Principal.Servicos;

namespace TeAjudo.Controllers
{
    public class TarefaController : Controller
    {
        //
        // GET: /Tarefa/
        //SolicitarTarefa solicitarTarefa;
        private readonly ITarefa repositorio;

        public TarefaController(ITarefa repositorioTarefa)
        {
            repositorio = repositorioTarefa;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Solicitar(Models.Principal.Modelos.Tarefa tarefa) {
            if (ModelState.IsValid) {
                var solicitarTarefa = new SolicitarTarefa(repositorio);
                solicitarTarefa.Solicitar(tarefa);
                return View("Sucesso");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Solicitar()
        {
            var tarefa = new Models.Principal.Modelos.Tarefa();
            return View(tarefa);
        }

        public ActionResult Sucesso() {
            return View();
        }

    }
}
