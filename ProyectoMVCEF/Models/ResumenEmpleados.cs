using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class ResumenEmpleados
    {
        public int MaximoSalario { set; get; }
        public int Personas { set; get; }
        public int SumaSalarial { set; get; }
        public double MediaSalarial { set; get; }
    }
}