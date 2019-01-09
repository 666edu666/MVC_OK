using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class HelperDoctores
    {
        EntidadHospital entidad;
        public HelperDoctores()
        {
            this.entidad = new EntidadHospital();
        }

        public List <paginacionSimpleDoctores_Result> GetDoctoresPaginacion(int cantidad)
        {
            return this.entidad.paginacionSimpleDoctores(cantidad).ToList();
        }

    }
}