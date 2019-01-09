using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCReal.Models
{
    public class Doctor
    {

        int hospitalCod;
        int doctorCod;
        String apellido;
        String especialidad;
        int salario;

        public Doctor(int hospC, int doctCod, String ape, String espe, int sal)
        {
            this.hospitalCod = hospC;
            this.doctorCod = doctCod;
            this.apellido = ape;
            this.especialidad = espe;
            this.salario = sal;
        }

        public int GetCodigoHospital()
        {
            return this.hospitalCod;
        }

        public int GetCodigoDoctor()
        {
            return this.doctorCod;
        }
        public String GetApellido()
        {
            return this.apellido;
        }
        public String GetEspecialidad()
        {
            return this.especialidad;
        }
        public int GetSalario()
        {
            return this.salario;
        }
    }
}