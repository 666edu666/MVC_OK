using RepositorioHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioHospital.Contexts
{
    public interface IHospitalContext
    {
        DbSet<Departamento> Departamentos { get; set; }
    }
}
