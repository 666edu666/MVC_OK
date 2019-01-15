using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC.Models
{
    public class HelperDepartamento
    {
        //Este helper hace uso de un mapeo custom que hemos creado con hospitalContext
        HospitalContext context;

        public HelperDepartamento()
        {
            this.context = new HospitalContext();
        }

        public List <Departamento> GetDepartamentos()
        {
            var consulta = from datos in context.Departamentos select datos;
            return consulta.ToList();
        }
        public Departamento GetDepartamento(int dept_no)
        {
            Departamento d  = ( from datos in context.Departamentos
                        where datos.Numero == dept_no
                           select datos).First();
            return d;
        }

        public void InsertarDepartamento (int num, String nom, String loc)
        {
            Departamento d = new Departamento();
            d.Numero = num;
            d.Nombre = nom;
            d.Localidad = loc;

            this.context.Departamentos.Add(d);
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int num, String nom, String loc)
        {
           //Single busca UN objeto que coincida con Numero, que a su vez una Primary Key
            Departamento d = this.context.Departamentos.Single(z=>z.Numero==num);
            //Cambio los valores                       
            d.Nombre = nom;
            d.Localidad = loc;
            //Confirmo los cambios

            this.context.SaveChanges();
            
        }
    }
}