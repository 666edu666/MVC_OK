using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RutesConceptos.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext():base("name=cadenahospital") { }

        public DbSet<Enfermo> Enfermos { set; get; }
    }
}