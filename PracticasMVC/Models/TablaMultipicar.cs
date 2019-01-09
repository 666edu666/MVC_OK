using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class TablaMultipicar
    {
        int num;
        public TablaMultipicar  (int n)
        {
            this.num = n;
        }
        public List<int> ListaTabla ()
        {
            List<int> lista = new List<int>();
            for (int i =1; i<11; i++)
            {
                lista.Add(i*this.num);
            }
            return lista;
        }

        public List<String> ListaTablaString()
        {
            //Es mejor crear un Model que tenga un campo llamado operacion y otro resultado.
            //De esa manera los tengo en dos campos separados y es más fácil 
            //para pintarlos 
            List<String> lista = new List<String>();
            
            for (int i = 1; i < 11; i++)
            {
                lista.Add(this.num.ToString()+"x"+i.ToString());
                lista.Add((i * this.num).ToString());
            }
            return lista;
        }
    }
}