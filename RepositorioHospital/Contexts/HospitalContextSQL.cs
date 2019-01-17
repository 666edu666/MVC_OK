using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioHospital.Models;

namespace RepositorioHospital.Contexts
{
    public class HospitalContextSQL : DbContext, IHospitalContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //indicamos que estamso accediendo
            //solamente a sql desde VS cuando vamos en una direccion
            Database.SetInitializer<HospitalContextSQL>(null);
            base.OnModelCreating(modelBuilder);
        }


        public HospitalContextSQL() : base("Data Source = LOCALHOST; Initial Catalog = HOSPITAL; Persist Security Info=True;User ID = SA; password=MCSD2018") { } //Coge el connectonString de Web.config


        public DbSet<Departamento> Departamentos { get; set; }
    }
}
