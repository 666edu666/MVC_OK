using PracticaDepartamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaDepartamentos.Repositories
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        HospitalContextSQL context;
        public RepositoryDepartamento()
        {
            this.context = new HospitalContextSQL();
        }
        public List <Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }
    }
}