using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Repositories;

namespace MVC_Practica_AWS.Controllers
{
    public class ApuestasController : Controller
    {
        private RepositoyChampions repo;
        public ApuestasController(RepositoyChampions repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Apuesta> apuestas =
                 this.repo.GetApuestas();
            return View(apuestas);
        }
        public IActionResult CrearApuesta()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CrearApuesta(Apuesta apuesta)
        {
            this.repo.CrearApuesta(apuesta.Usuario, apuesta.IdEquipoLocal, apuesta.IdEquipoVisitante, apuesta.GolLocal, apuesta.GolVisitante);
            return RedirectToAction("Index", "Apuestas");
        }
    }
}
