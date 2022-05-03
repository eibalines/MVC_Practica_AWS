using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Repositories;

namespace MVC_Practica_AWS.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoyChampions repo;
        public JugadoresController(RepositoyChampions repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Jugador> jugadores =
                this.repo.GetTodosJugadores();
            return View(jugadores);
        }
        public IActionResult JugadoresEquipo(int idequipo)
        {
            List<Jugador> jugadores =
                this.repo.JugadoresEquipo(idequipo);
            return View(jugadores);
        }

        public IActionResult CrearJugador()
        {
            return View();
        }
    }
}
