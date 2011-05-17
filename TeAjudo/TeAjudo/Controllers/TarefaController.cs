using System.Web.Mvc;
using TeAjudo.Apresentacao.Modelos;
using TeAjudo.Models.Principal.Modelos;
using TeAjudo.Models.Principal.Repositorios;
using TeAjudo.Apresentacao.Atributos;
using AutoMapper;

namespace TeAjudo.Controllers
{
    //[AutoMap]
    public class TarefaController : BaseController
    {
        private readonly ITarefaRepositorio repositorio;

        public TarefaController(ITarefaRepositorio repositorioTarefa)
        {
            repositorio = repositorioTarefa;
        }

        [HttpPost]
        //[AutoMap(typeof(Apresentacao.Modelos.Tafera), typeof(Models.Principal.Modelos.Tarefa))]
        public ActionResult Solicitar(Apresentacao.Modelos.Tafera modelo) {
            if (ModelState.IsValid)
            {
                var tarefa = new TeAjudo.Models.Principal.Modelos.Tarefa(repositorio);
                Mapper.CreateMap<Apresentacao.Modelos.Tafera, Models.Principal.Modelos.Tarefa>();
                Mapper.Map(modelo, tarefa);
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

    }
}
