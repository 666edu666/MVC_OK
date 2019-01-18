
using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Repositories
{
    public class RepositoryEmpleados
    {
        HospitalContext context;
        public RepositoryEmpleados()
        {
            this.context = new HospitalContext();
        }
        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }

        public List <Empleado> BuscarEmpleadosSession (List <int> codigos)
        {
            var consulta = from datos in context.Empleados
                           where codigos.Contains(datos.IdEmpleado)
                           select datos;
            return consulta.ToList();
        }
    }
}