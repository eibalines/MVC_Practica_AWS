using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Repositories;
using MVC_Practica_AWS.Services;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MVC_Practica_AWS.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoyChampions repo;
        private ServiceAWSS3 service;
        public JugadoresController(RepositoyChampions repo, ServiceAWSS3 service)
        {
            this.repo = repo;
            this.service = service;
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
        [HttpPost]
        public async Task<IActionResult> CrearJugador(Jugador jugador, IFormFile file)
        {
            this.repo.CrearJugador(jugador.Nombre, jugador.Posicion, file.FileName, jugador.IdEquipo);
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, file.FileName);
            }
                return RedirectToAction("Index", "Jugadores");
        }
    }
}
