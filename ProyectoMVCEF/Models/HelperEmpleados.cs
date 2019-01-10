using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;


namespace ProyectoMVCEF.Models
{

    
    public class HelperEmpleados
    {
        
        //Entity, context
        EntidadHospital entidad;
       

        public HelperEmpleados()
        {
            this.entidad = new EntidadHospital();
        }
        public List <String> GetOficios()
        {
            var consulta = (from datos in entidad.EMP select datos.OFICIO).Distinct();
            return consulta.ToList();
        }

        public List<EMP> GetEmpleadosOficio (String oficio)
        {
            var consulta = (from datos in entidad.EMP where datos.OFICIO == oficio
                            select datos);
            return consulta.ToList();
        }
    
        public ResumenEmpleados GetResumenEmpleados(String oficio)
        {
            //List<EMP> empleados = this.GetEmpleadosOficio(oficio);
            List<EMP> empleados = this.GetEmpleadosDepartamento(int.Parse(oficio));



            int personas = empleados.Count;
            
            //Con esto lo que hago es buscar de la propiedad SALARIO su MAX
            //Puede ser nullable
            int? maximo = empleados.Max(z => z.SALARIO);
            System.Nullable<int> suma = empleados.Sum(t=>t.SALARIO);
            double? media = empleados.Average(j=>j.SALARIO);

            
            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.MaximoSalario = maximo.GetValueOrDefault();
            resumen.Personas = personas;
            resumen.SumaSalarial = suma.GetValueOrDefault();
            resumen.MediaSalarial = media.GetValueOrDefault();

            return resumen;
        }

       
       //////////////////////////////////////////////////////////////////////////////////////        

        public List<DEPT> GetDepartamentos()
        {
            var consulta = (from datos in entidad.DEPT select datos);
            return consulta.ToList();
        }


        public List<EMP> GetEmpleadosDepartamento(int dept_no)
        {
            var consulta = (from datos in entidad.EMP
                            where datos.DEPT_NO == dept_no
                            select datos);
            return consulta.ToList();
        }

        public List <EMP> GetEmpleados(int orden)
        {
            
            if (orden==0)
            {
                var consulta = (from datos in entidad.EMP
                                orderby datos.APELLIDO ascending
                                select datos);
                return consulta.ToList();
            }
            else if(orden==1)
            {
                var consulta = (from datos in entidad.EMP
                                orderby datos.APELLIDO descending
                                select datos);
                return consulta.ToList();
            }
             else if (orden == 2)
            {
                var consulta = (from datos in entidad.EMP
                                orderby datos.SALARIO descending
                                select datos);
                return consulta.ToList();
            }
            else if(orden==3)
            {
                var consulta = (from datos in entidad.EMP
                                orderby datos.SALARIO ascending
                                select datos);
                return consulta.ToList();
            }
            return null;
        }


        //empleadosInfo_Result es un complexType porque viene de un procedimiento
        //que devuelve todas las columnas de EMP y dos más de DEPT. Por ello
        //por ello es un type diferente. Si devolviera las misma columnas por ejemplo
        // de EMP podría mapearlo a esa clase que ya tenemos.
        public empleadosInfo_Result GetEmpleadosInfo(int posicion)
        {
            #region procedimiento
            //alter procedure empleadosInfo(@posicion int)
            //as
            //    select* from(select ROW_NUMBER() over(order by EMP.apellido) as posicion, EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO, DEPT.DNOMBRE, DEPT.LOC

            //   from EMP inner join DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO) Pikachi where posicion = @posicion
            //go
            #endregion
            var consulta = this.entidad.empleadosInfo(posicion);
            empleadosInfo_Result empleado = consulta.FirstOrDefault();
            return empleado;
             
        }
        public int GetNumeroEmpleados()
        {
            return this.entidad.EMP.Count();
        }

        public ResumenEmpleados GetResumenParametrosSalida(int departamento)
        {
            //Parámetros de salida PROCEDIMIENTOS

            //Se llaman con ObjectParameter
            //Indicamos el nombre del parámetro y su tipo
            ObjectParameter pamPersonas = new ObjectParameter("PERSONAS", typeof(int));
            ObjectParameter pamMedia = new ObjectParameter("MEDIA", typeof(int));
            ObjectParameter pamSuma = new ObjectParameter("SUMA", typeof(int));

            this.entidad.datosdepartamentos(departamento, pamPersonas, pamSuma, pamMedia);

            //Comprobar los valores que me ha devuelto
            if (pamSuma.Value == System.DBNull.Value)
            {
                return null;
            }

            ResumenEmpleados resumen = new ResumenEmpleados();
            resumen.Personas = (int)pamPersonas.Value;
            resumen.MediaSalarial = (int)pamMedia.Value;
            resumen.SumaSalarial = (int)pamSuma.Value;

            return resumen;
        }

        public List<paginar_empleados_grupo_Result> GetEmpleadosGrupo(int posicion, ref int totalRegistros)
        {
            #region procedure 
                //create procedure paginar_empleados_grupo(@posicion int, @totalRegistros int out)
                //as
                //    select @totalRegistros = COUNT(EMP_NO) from EMP

                //    select * from 

                //        (select ROW_NUMBER() over(order by APELLIDO) as posicion, APELLIDO, SALARIO, OFICIO FROM EMP) EMPLEADOS
                //           where POSICION >= @posicion and posicion< (@posicion+3)
                //go
            #endregion

            ObjectParameter pamTotal = new ObjectParameter("totalRegistros", typeof (int));
            
            var datos = this.entidad.paginar_empleados_grupo(posicion, pamTotal);

            
            List<paginar_empleados_grupo_Result> empleados = datos.ToList();
            totalRegistros = (int)pamTotal.Value;


            return empleados;
        }

        public List <paginarDoctorPlantillaEmpleado_Result> PaginacionDoctorPlantillaEmpleado(int posicion,int salario, ref int totalRegistros)
        {
            ObjectParameter pamTotal = new ObjectParameter("totalRegistros", typeof(int));
            var datos = this.entidad.paginarDoctorPlantillaEmpleado(salario, posicion, pamTotal).ToList();
            List<paginarDoctorPlantillaEmpleado_Result> emp = datos.ToList();
                
            totalRegistros = (int)pamTotal.Value;
            
            return emp;
        }
    }
}