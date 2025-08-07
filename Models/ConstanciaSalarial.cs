using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ConstanciaSalarial
    {
        public int? idEmpleado { get; set; }
        public string identificacion { get; set; }
        public string nombreCompleto { get; set; }
        public float? salarioBruto { get; set; }
        public DateTime? fechaContratacion { get; set; }
        public char? activo { get; set; }
        public string departamento { get; set; }
        public string puesto { get; set; }
        public string tipoContrato { get; set; }
    }
}