using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class HistorialSalarios
    {
        public int idHistorialSalario { get; set; }
        public float? salarioAnterior { get; set; }
        public float? salarioNuevo { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public int? idEmpleado { get; set; }
    }
}