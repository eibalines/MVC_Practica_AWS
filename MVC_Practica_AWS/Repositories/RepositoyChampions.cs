using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Practica_AWS.Models;
using MVC_Practica_AWS.Data;

namespace MVC_Practica_AWS.Repositories
{
    public class RepositoyChampions
    {
        private ChampionsContext context;
        public RepositoyChampions(ChampionsContext context)
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


        public List<Jugador> GetTodosJugadores()
        {
            return this.context.Jugadores.ToList();
        }


        public List<Jugador> JugadoresEquipo(int idequipo)
        {
            var consulta = from datos in this.context.Jugadores
                           where datos.IdEquipo == idequipo
                           select datos;

            return consulta.ToList();
        }

        public int GetMaxJugadoresId()
        {
            if (this.context.Jugadores.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Jugadores.Max(z => z.IdJugador) + 1;
            }
        }

        public void CrearJugador(string nombre, string posicion, string imagen, int idequipo)
        {
            Jugador jugador = new Jugador
            {
                IdJugador = this.GetMaxJugadoresId(),
                Nombre = nombre,
                Posicion = posicion,
                Imagen = "http://acs.amazonaws.com/groups/global/AllUsers/" + imagen,
                IdEquipo = idequipo

        };
            this.context.Jugadores.Add(jugador);
            this.context.SaveChanges();
        }



        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }
        public int GetMaxApuestasId()
        {
            if (this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            }
        }
        public void CrearApuesta(string usuario, int idlocal, int idvisitante, int gollocal, int golvisitante)
        {
            Apuesta apuesta = new Apuesta
            {
                IdApuesta = this.GetMaxApuestasId(),
                Usuario = usuario,
                IdEquipoLocal = idlocal,
                IdEquipoVisitante = idvisitante,
                GolLocal = gollocal,
                GolVisitante = golvisitante
            };
            this.context.Apuestas.Add(apuesta);
            this.context.SaveChanges();
        }
    }
}
