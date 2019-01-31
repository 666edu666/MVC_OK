using ExcepcionesControl.Context;
using ExcepcionesControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcepcionesControl.Repository
{
    public class HospitalRepository
    {
        HospitalContext context;

        public HospitalRepository()
        {
            this.context = new HospitalContext();
        }

        public void InsertarDoctor(int doctorno, int hospital, String apellido,
            String especialidad, int salario) {

            Doctor doc = new Doctor();
            doc.IdDoctor = doctorno;
            doc.CodigoHospital = hospital;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;

            this.context.Doctores.Add(doc);
            this.context.SaveChanges();
        }

        public List<Doctor> GetDoctores() {

            return this.context.Doctores.ToList();
        }
        public int GetMaxExcepcion() {
            if (this.context.Excepciones.Count() == 0)
            {
                return 1;
            }
            else {
                return this.context.Excepciones.Max(z=>z.IdExcepcion);
            }
        }

        public void InsertarExcepcion(String mensaje, String controlador,
            DateTime fecha) {
            Excepcion e = new Excepcion();
            e.IdExcepcion = this.GetMaxExcepcion();
            e.Controlador = controlador;
            e.Fecha = fecha;
            e.Mensaje = mensaje;

            this.context.Excepciones.Add(e);
            this.context.SaveChanges();
        }
    }
}