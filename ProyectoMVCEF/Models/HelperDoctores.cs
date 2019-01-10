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
            #region procedure 
            //create procedure paginacionSimpleDoctores(@posicion int)
            //as
            //    select* from
            //   (select ROW_NUMBER() over(order by DOCTOR.APELLIDO) as posicion, DOCTOR.APELLIDO, DOCTOR.SALARIO, DOCTOR.ESPECIALIDAD, HOSPITAL.NOMBRE as 'NombreHospital'

            //       from DOCTOR inner join HOSPITAL on DOCTOR.HOSPITAL_COD = HOSPITAL.HOSPITAL_COD) Pikachu where posicion between 0 and @posicion
            //go
            #endregion

            return this.entidad.paginacionSimpleDoctores(cantidad).ToList();
        }

    }
}