using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Models
{
    public class Video
    {
        String cod;
        String texto;
        public Video(String c, String tex)
        {
            this.cod = c;
            this.texto = tex;
        }
        public String CodigoYoutube() { return cod; }
        public String TextoYoutube() { return texto; }
    }
}