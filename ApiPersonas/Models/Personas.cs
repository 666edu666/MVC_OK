using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPersonas.Models
{
    public class Personas
    {
        public int IdPersona { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public int Edad { get; set; }
    }
}