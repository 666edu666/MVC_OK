using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticaDepartamentos.Models
{
    [Table("DEPT")]
    public class Departamento 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("DEPT_NO")]
        public int DepartamentoCodigo { get; set;}

        [Column("DNOMBRE")]
        public String DepartamentoNombre { get; set; }


        [Column("LOC")]
        public String DepartamentoLocalidad { get; set; }
    }
}