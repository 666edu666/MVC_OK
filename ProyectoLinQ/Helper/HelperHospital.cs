using ProyectoLinQ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProyectoLinQ.Helper
{
    public class HelperHospital
    {
        ContextoHospitalDataContext contexto;

        public HelperHospital()
        {
            this.contexto = new ContextoHospitalDataContext();
        }

        public List<String> GetOficios()
        {
            var consulta = (from datos in contexto.EMPs select datos.OFICIO).Distinct();
            return consulta.ToList();
        }
        public List<EMP> GetEmpleados()
        {
            var consulta = from datos in contexto.EMPs select datos;
            return consulta.ToList();
        }
        public List<EMP> GetEmpleadosOficio(String ofi)
        {
            var consulta = from datos in contexto.EMPs where datos.OFICIO == ofi select datos;
            return consulta.ToList();
        }

        public int ModificarEmpleados(String ofi, int incre)
        {
            var consulta = from datos in contexto.EMPs where datos.OFICIO == ofi select datos;
            int total = consulta.Count();
            if (total == 0)
            {
                return total;
            }
            else
            {
                foreach (EMP e in consulta)
                {
                    //Debug.WriteLine("Salario original"+e.SALARIO);
                    int oldSalario = e.SALARIO.Value;
                    //Debug.WriteLine("Salario incrementado" + oldSalario + incre);
                    e.SALARIO += 1;
                }
                
                contexto.SubmitChanges();
                return total;
            }
        }

        public List<DEPT> GetDepartamentos()
        {
            var consulta = from datos in contexto.DEPTs select datos;
            return consulta.ToList();
        }
        public List<EMP> GetEmpleadosDepartamento(int codD)
        {
            var consulta = from datos in contexto.EMPs where datos.DEPT_NO==codD select datos;
            return consulta.ToList();
        }
    }
}