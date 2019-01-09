using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class HelperEnfermo
    {
        #region procedure
        //create procedure eliminarEnfermo(@inscripcion int)
        //as
        //	delete from enfermo where inscripcion = @inscripcion
        //go

        //create procedure mostrarEnfermos
        //as
        //	select* from enfermo
        //go
        #endregion

        EntidadHospital entidad;
        public HelperEnfermo()
        {
            this.entidad = new EntidadHospital();
        }

        public int EliminarEnfermo(int inscripcion)
        {
            return this.entidad.eliminarEnfermo(inscripcion); //Devuelve el número de "afectados"
        }

        public List <ENFERMO> GetEnfermos()
        {
            List<ENFERMO> enfermos = this.entidad.mostrarEnfermos().ToList();
            return enfermos;
        }
    }
}