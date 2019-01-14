using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HelperDepartamento
    {
        ContextoHospitalConceptosMVC entidad;

        public HelperDepartamento()
        {
            this.entidad = new ContextoHospitalConceptosMVC();
        }

        public List <DEPT> GetDepartamentos()
        {
            var consulta = from datos in entidad.DEPTs select datos;
            return consulta.ToList();
        }
        public DEPT GetDepartamento(int dept_no)
        {
            DEPT d  = ( from datos in entidad.DEPTs
                           where datos.DEPT_NO == dept_no
                           select datos).First();
            return d;
        }
    }
}