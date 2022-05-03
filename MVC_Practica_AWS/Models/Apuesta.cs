﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Practica_AWS.Models
{
    [Table("APUESTAS")]
    public class Apuesta
    {
        [Key]
        [Column("IDAPUESTA")]
        public int IdApuesta { get; set; }

        [Column("USUARIO")]
        public string Usuario { get; set; }

        [Column("IDEQUIPOLOCAL")]
        public int IdEquipoLocal { get; set; }

        [Column("IDEQUIPOVISITANTE")]
        public int IdEquipoVisitante { get; set; }
    
        [Column("GOLESEQUIPOLOCAL")]
        public int GolLocal { get; set; }

        [Column("GOLESEQUIPOVISITANTE")]
        public int GolVisitante { get; set; }

    }
}
