using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Contrato
    {
        public int idContrato { get; set; }
        public string tipoContrato { get; set; }
        public char? estadoContrato { get; set; }
        public string adicionadoPor { get; set; }
        public DateTime? fechaAdicion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public int? idEmpleado { get; set; }
    }
}