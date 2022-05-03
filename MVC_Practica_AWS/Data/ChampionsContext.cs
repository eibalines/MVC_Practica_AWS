using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Practica_AWS.Models;

namespace MVC_Practica_AWS.Data
{ 
    public class ChampionsContext: DbContext
    {
        public ChampionsContext(DbContextOptions<ChampionsContext> options) : base(options) { }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
    }
}
