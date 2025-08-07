using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenna { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string modificadoPor { get; set; }
        public int? idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
    }
}