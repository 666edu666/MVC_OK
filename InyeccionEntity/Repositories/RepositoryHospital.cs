using InyeccionEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InyeccionEntity.Repositories
{
    public class RepositoryHospital :IRepositoryHospital
    {
        HospitalContext context;


        //Inyeccion de dependencias
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public List <Hospital> GetHospitales()
        {
            //var consulta = from datos in context.Hospitales select datos;
            //return consulta.ToList();

            return context.Hospitales.ToList(); // Es lo mismo que la consulta superior
        }
    }
}