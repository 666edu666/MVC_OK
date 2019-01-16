using InyeccionEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InyeccionEntity.Repositories
{
    public interface IRepositoryHospital
    {
        //No se le indica el modificador de acceso (public, protected...) al ser INTERFACE
        List<Hospital> GetHospitales();
    }
}