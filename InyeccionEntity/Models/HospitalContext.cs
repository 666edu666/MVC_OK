using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InyeccionEntity.Models
{
    //Heredo de :DbCotext que es el nugget que he instalado (EntityFramework)
    //Esto es por mapear de forma manual, cuando creamos un EDMX esto lo hace automático

    public class HospitalContext : DbContext
    {

        //Con esto le estoy diciendo que estoy "tirando" de SQL a VISUAL ESTUDIO
        //Se podría hacer al revés también
        //soluciona el error "BACKIND"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HospitalContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public HospitalContext ():base("name=cadenahospital") { } //Coge el connectonString de Web.config


        public DbSet<Hospital> Hospitales { get; set;}
    }
}