using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Data;

namespace MVC_Practica_AWS.Repositories
{
    public class ChampionsRepository
    {
        private ChampionsContext context;
        public ChampionsRepository(ChampionsContext context)
        {
            this.context = context;
        }
        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public Equipo FindEquipo(int idequipo)
        {
            return this.context.Equipos.FirstOrDefault(x => x.IdEquipo == idequipo);
        }



        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }



        public List<Jugador> GetJugadores()
        {
            return this.context.Jugadores.ToList();
        }

    }
}
