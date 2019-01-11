using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class HelperHospital
    {
        EntidadHospital entidad;

        public HelperHospital()
        {
            this.entidad = new EntidadHospital();
        }

        public List <HOSPITAL> GetHospitales()
        {
            var consulta = from datos in entidad.HOSPITAL select datos;
            return consulta.ToList();
        }

        public List <PLANTILLA> GetPlantilla(int [] codHosp,int orden)
        {
            if (orden==0)
            {
                var consulta = (from datos in entidad.PLANTILLA
                                where codHosp.Contains(datos.HOSPITAL_COD.Value)
                                orderby datos.APELLIDO ascending
                                select datos);
                return consulta.ToList();
            }
            else if (orden==1)
            {
                var consulta = (from datos in entidad.PLANTILLA
                                where codHosp.Contains(datos.HOSPITAL_COD.Value)
                                orderby datos.APELLIDO descending
                                select datos);
                return consulta.ToList();
            }
            return null;
        }
    }
}