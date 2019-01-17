using RepositorioHospital.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Repositories
{
    public interface IRepositoryEmpleados
    {
        List<EMP> GetEmpleados();
    }
}
