using RepositorioHospital.Contexts;
using RepositorioHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Repositories
{
    class RepositoryDepartamentos : IRepositoryDepartamentos
    {
        IHospitalContext context;

        public RepositoryDepartamentos(IHospitalContext context) { this.context = context; }
        public List<Departamento> GetDepartamentos() {
            return this.context.Departamentos.ToList();
        }
    }
}
