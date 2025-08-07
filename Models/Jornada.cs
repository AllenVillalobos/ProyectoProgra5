﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Jornada
    {
        public int idJornada { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public char? estado { get; set; }
        public int? horasSemanales { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}