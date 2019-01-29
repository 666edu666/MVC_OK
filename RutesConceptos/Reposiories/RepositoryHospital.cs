using RutesConceptos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RutesConceptos.Reposiories
{
    public class RepositoryHospital
    {
        HospitalContext context;

        public RepositoryHospital() {
            this.context = new HospitalContext();
        }

        public List<Enfermo> GetEnfermos() {
            return this.context.Enfermos.ToList();
        }
        public Enfermo BuscarEnfermo(String incripcion) {
            return this.context.Enfermos.Single(z =>z.Inscripcion == incripcion);
        }

        public void EliminarEnfermo(String inscripcion) {
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            this.context.Enfermos.Remove(enfermo);
            this.context.SaveChanges();
        }
    }
}