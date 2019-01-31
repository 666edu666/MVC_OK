using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExcepcionesControl.Models
{
    [Table("EXCEPCIONES")]
    public class Excepcion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column("idexception")]
        public int IdExcepcion { get; set; }

        [Column("MENSAJE")]
        public String Mensaje { get; set; }

        [Column("CONTROLADOR")]
        public String Controlador { get; set; }

        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }
}