using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Contacto
    {           
        public int idContacto { get; set; }
        public string tipoContacto { get; set; }
        public string infoContacto { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public int? idEmpleado { get; set; }
    }
}