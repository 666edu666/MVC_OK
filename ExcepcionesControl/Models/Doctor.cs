﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExcepcionesControl.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_NO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDoctor { get; set; }

        [Column("HOSPITAL_COD")]
        public int CodigoHospital  { get; set; }



        [Column("APELLIDO")]
        public String Apellido { get; set; }


        [Column("ESPECIALIDAD")]
        public String Especialidad { get; set; }


        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}