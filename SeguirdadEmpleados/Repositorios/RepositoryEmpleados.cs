using SeguirdadEmpleados.Context;
using SeguridadEmpleados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguirdadEmpleados.Repositorios
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;

        public RepositoryEmpleados()
        {
            this.context = new EmpleadosContext();
        }
        //Necesitamos un metodo para devolver un empleado por su apellido y empNo

        public Empleado ExisteEmpleado(String apellido, int empno)
        {
            var consulta = from datos in context.Empleados
                           where datos.Apellido == apellido && datos.IdEmpleado == empno
                           select datos;
            return consulta.FirstOrDefault();
                           
        }
        //Metodo para devolver los subordinados de un empleado
        public List<Empleado> GetEmpleadosSubordinados(int director) {
            var consulta = from datos in context.Empleados
                           where datos.Director == director
                           select datos;
            if (consulta.Count()==0) { //Si no existe es mejor devolver un null a una lsita vacía
                return null;
            }
            else
            {
                return consulta.ToList();
            }
        }

        //Metodo para buscar un Empleado por su EMPNO
        public Empleado BuscarEmpleado(int empno) {
            var consulta = from datos in context.Empleados
                           where datos.IdEmpleado == empno
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void ModificarEmpleado(int empno, String apellido, String oficio, int salario) {
            Empleado em = new Empleado();
            em.Apellido = apellido;
            em.Oficio = oficio;
            em.Salario = salario;
            this.context.SaveChanges();
        }
    }
}