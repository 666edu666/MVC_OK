using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class Persona
    {

        //Creo un modelo de persona  para ser representado en una vista. Es especialmente útil cuando voy a 
        //representar el objeto, en este caso una persona, numerosas veces.

    //La validaciones que hace aqui son solo a nivel HTML cn etiquetas como Required o MaxLength.
    //Para más validaciones:



        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombre { get; set; }


        [Required(ErrorMessage = "El apellido es obligatorio")]
        public String Apellido { get; set; }


        [EmailAddress(ErrorMessage = ("Direccion de email incorrecta"))]
        [Required(ErrorMessage = "El email es obligatorio")]
        [Display(Description = "Correo electrónico")]
        public String Email { get; set; }


        [DataType(DataType.Date)]
        public String FechaNacimiento {get;set;}

        [DataType(DataType.Password)]
        public String  Password { get; set; }

        [Compare("Password", ErrorMessage ="Password deben ser iguales")]
        [DataType (DataType.Password)]
        public String RepetirPassword { get; set; }

        

    }
}