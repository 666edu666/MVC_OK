using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ProyectoMVCReal.Models;

//Para poder escribir en consola usando Debug.WriteLine()
using System.Diagnostics;

namespace ProyectoMVCReal.Helper
{
    public class HelperLinqDepartamentos
    {
        //EL contexto será el objeto de acceso a datos, siempre llamara nombre_contextoDataContext
        ContextoHospitalDataContext contexto;


        public HelperLinqDepartamentos()
        {
            this.contexto = new ContextoHospitalDataContext();
        }
        public List<DEPT> GetDepartamentos()
        {
            var consulta = from t in contexto.DEPTs select t;
            return consulta.ToList();
        }

        public DEPT BuscarDepartamento(String loc)
        {
            var consulta = from t in contexto.DEPTs where t.LOC == loc select t;
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.First();
            }
        }

        public void InsertaDepartamento(int numero, String nombre, String loc)
        {
            DEPT d = new DEPT();
            d.DEPT_NO = numero;
            d.DNOMBRE = nombre;
            d.LOC = loc;

            //Recuperamos los datos del contexto. Para insertar agregamos el objeto al contexto
            contexto.DEPTs.InsertOnSubmit(d); //Aqui lo tengo en LinQ no en la BBDD

            //Con esto confirmo los cambios para que TODO lo que tenga en contexto pasarlo a BBDD
            contexto.SubmitChanges();
        }

        public int EliminarDepartamento(int deptno)
        {
            //Bucamos el DEPT por el dept_no. First coge el primero, ¿Y si no encuentra el dept??==>EXCEPCION
            //DEPT d = (from datos in contexto.DEPTs where datos.DEPT_NO == deptno select datos).First();

            //FirstOrDefault coge el primero si existe, y si no es null
            DEPT d = (from datos in contexto.DEPTs where datos.DEPT_NO == deptno select datos).FirstOrDefault();
            if (d == null)
            {
                return 0;
            }
            else
            {
                //Lo borramos de LinQ
                contexto.DEPTs.DeleteOnSubmit(d);
                //Trasladamos los cambios de LinQ a la BBDD
                contexto.SubmitChanges();
                return 1;
            }
        }

        public int ModificarDepartamento(String oldLoc, String newLoc)
        {
            var consulta = from datos in contexto.DEPTs where datos.LOC == oldLoc select datos;

            //Debug.WriteLine("Antes submit"+consulta.Count());
            if (consulta.Count() == 0)
            {
                //No encuentra ningún DEPT con esa LOC
                return 0;
            }
            else
            {
                foreach (DEPT d in consulta)
                {
                    d.LOC = newLoc;
                }
                int nume = consulta.Count();
                //Al hacer el submitChanges se libera la var consulta, por lo que el count() siempre=0.
                //Tenemos que guardar el valor antes del submit
                contexto.SubmitChanges();
                
                //Console.WriteLine("Despues submit" + consulta.Count());
                return nume;
            }
        }

        public List<String> GetLocalidades()
        {
           //El distinct se aplica en C# con LinQ
            var consulta = (from datos in contexto.DEPTs select datos.LOC).Distinct();

            return consulta.ToList();
        }

        //public List<int?> GetLocalidades()
        //{

        //    var consulta = from datos in contexto.DEPTs select datos.DEPT_NO;

        //    return consulta.ToList();
        //}
    }
}