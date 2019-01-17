using RepositorioHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Repositories
{
    public interface IRepositoryDepartamentos
    {
        List<Departamento> GetDepartamentos();
    }
}
