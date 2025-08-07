using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Rol
    {
        public int idRol { get; set; }
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string modificadoPor { get; set; }
    }
}