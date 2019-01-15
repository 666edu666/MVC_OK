using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel; //Para usarlo como modelo para las vistas

namespace ConceptosMVC.Models
{
    [Table("DEPT")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO") ]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Numero { get; set; }


        [Column("DNOMBRE")]
        [StringLength(50)] //EntityFramework va a cortar este String en length=50.
        [Required (ErrorMessage ="El nombre es obligatorio")]
        public String Nombre { get; set; }



        [Column("LOC")]
        [Required (ErrorMessage ="La localidad es obligatoria")]
        public String Localidad { get; set; }
    }
}