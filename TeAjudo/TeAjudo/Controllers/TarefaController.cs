using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeAjudo.Models.Principal;

namespace TeAjudo.Controllers
{
    public class TarefaController : Controller
    {
        //
        // GET: /Tarefa/
        Models.Principal.Servicos.SolicitarTarefa solicitarTarefa;        

        public TarefaController(Models.Principal.Repositorios.ITarefa repositorioTarefa) {            
            solicitarTarefa = new Models.Principal.Servicos.SolicitarTarefa(repositorioTarefa);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Solicitar(Models.Principal.Modelos.Tarefa tarefa) {
            if (ModelState.IsValid) {
                solicitarTarefa.Solicitar(tarefa);
                RedirectToAction("Sucesso");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Solicitar()
        {
            Models.Principal.Modelos.Tarefa tarefa = new Models.Principal.Modelos.Tarefa();
            return View(tarefa);
        }

        public ActionResult Sucesso() {
            return View();
        }

    }
}
