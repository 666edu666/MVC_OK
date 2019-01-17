using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioHospital.Contexts;


namespace RepositorioHospital.Repositories
{
    public class RepositoryEmpleados : IRepositoryEmpleados
    {
        HOSPITALEntities1 contexto;

        public RepositoryEmpleados(HOSPITALEntities1 contexto) { this.contexto = contexto; }
        public List<EMP> GetEmpleados()
        {
            return this.contexto.EMP.ToList();
        }
    }
}
