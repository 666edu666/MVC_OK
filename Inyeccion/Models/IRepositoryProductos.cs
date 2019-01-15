using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inyeccion.Models
{
    public interface IRepositoryProductos
    {
        //Solo lleva la declaración, no l aimplementación.

        //Ej: quiero en mi clase repo un método GetProductos

        List<Producto> GetProductos();
    }
}