using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;

namespace PracticaDepartamentos.Models
{
    public class HospitalContextORACLE :DbContext
    {
        public HospitalContextORACLE() :base("name=cadenahospitaloracle") { }

    }
}