using PracticaDepartamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaDepartamentos.Repositories
{
    public interface IRepositoryDepartamento
    {
        List<Departamento> GetDepartamentos();
    }
}