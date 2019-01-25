using ConceptosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Repositories
{
    public class RepositoryHospital
    {
        HospitalContext context;
        public RepositoryHospital() {
            this.context = new HospitalContext();
        }
        public List<Departamento> GetDepartamento() {
            return this.context.Departamentos.ToList();
        }

        public List<Empleado> GetEmpleadosDepartamento(int deptno)
        {
            var consulta = from datos in context.Empleados
                           where datos.IdDepartamento == deptno
                           select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleados()
        {            
            return this.context.Empleados.ToList();
        }

        public Empleado GetEmpleado(int idEmp) {
            var consulta = from datos in context.Empleados
                           where datos.IdEmpleado == idEmp
                           select datos;
            Empleado e = consulta.First();
            return e;
        }
        public void BorrarEmpleado(int idEmp)
        {
            var consulta = from datos in context.Empleados
                           where datos.IdEmpleado == idEmp
                           select datos;
            Empleado e = consulta.First();
            this.context.Empleados.Remove(e);
            this.context.SaveChanges();
        }
    }
}