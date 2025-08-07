using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class HistorialPuesto
    {
        public int idEmpleado { get; set; }
        public int? idPuesto { get; set; }
        public char? estado { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string modificadoPor { get; set; }
    }
}