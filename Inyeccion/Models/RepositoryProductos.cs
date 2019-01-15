using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inyeccion.Models
{
    public class RepositoryProductos :IRepositoryProductos
    {
        List<Producto> productos;

        private void CrearProductos()
        {
            this.productos = new List<Producto>();
            productos.AddRange(new Producto[] {
                new Producto()
                {
                    Nombre="producto1",
                    Imagen="1.jpg",
                    Precio =1
                },
                new Producto()
                {
                    Nombre="producto2",
                    Imagen="2.jpg",
                    Precio =2
                },
                new Producto()
                {
                    Nombre="producto3",
                    Imagen="3.jpg",
                    Precio =3
                }
            });
        }
        public RepositoryProductos()
        {
            this.CrearProductos();
        }

        public List <Producto> GetProductos()
        {
            return productos;
        }

    }
}