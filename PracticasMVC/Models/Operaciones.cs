using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class Operaciones
    {
        int num1;
        int num2;
        public Operaciones(int n1, int n2){
            this.num1 = n1;
            this.num2 = n2;
        }
        public int sumado()
        {
            return this.num1 + this.num2;
        }
    }
}