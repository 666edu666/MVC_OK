using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SeguridadEmpleados.Model
{
    [Table("EMP")]
    public class Empleado : IPrincipal
    {
        [Key]
        [Column("EMP_NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmpleado { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("OFICIO")]
        public String Oficio { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
        [Column("DIR")]
        public int Director { get; set; }
        public IIdentity Identity { get; set; }

        //Para crear usuarios principal, que necesitamos?
        //public Empleado(IIdentity identidad, String[] roles)
        //{
        //    this.Identity = identidad;
        //    this.Roles = roles;
        //}

        //private String[] Roles;
        public Empleado(IIdentity identidad)
        {
            this.Identity = identidad;
        }
        public Empleado() { }

        public bool IsInRole(string role)
        {
            if (this.Oficio.ToUpper() == role.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
            //foreach (String r in this.Roles)
            //{
            //    if(r.ToUpper() == role.ToUpper())
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
    }
}