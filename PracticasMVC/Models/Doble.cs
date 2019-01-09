using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class Doble
    {
        int numero;
        public Doble(int n)
        {
            this.numero = n;
        }
        public int Calcula()
        {
            return this.numero * 2;
        }
        
    }
}