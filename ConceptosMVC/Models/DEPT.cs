//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConceptosMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DEPT
    {
        [Required (ErrorMessage="El n�mero del departamento es obligatorio")]

        public int DEPT_NO { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        public string DNOMBRE { get; set; }

        [Required(ErrorMessage = "La localidad del departamento es obligatoria")]
        [MaxLength(10,ErrorMessage ="La longitud m�xima del campo localidad son 10 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud m�nima del campo localidad son 2 caracteres")]
        //[RegularExpression(@"^[A-Za-z������������_-]$",ErrorMessage ="La localidad no cumple con el formato")]

        public string LOC { get; set; }
    }
}