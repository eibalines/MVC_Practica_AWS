using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Repositories;

namespace MVC_Practica_AWS.Controllers
{
    public class EquiposController : Controller
    {
        private RepositoyChampions repo;
        public EquiposController(RepositoyChampions repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Equipo> equipos =
                this.repo.GetEquipos();
            return View(equipos);
        }
    }
}
