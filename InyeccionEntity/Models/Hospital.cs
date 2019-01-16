using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InyeccionEntity.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("HOSPITAL_COD")]
        public string IdHospital { get; set; }


        [Column("NOMBRE")]
        public string Nombre { get; set; }


        [Column("DIRECCION")]
        public string Direccion { get; set; }


        [Column("TELEFONO")]
        public string Telefono { get; set; }

        [Column("NUM_CAMA")]
        public string Camas { get; set; }

        
    }
}