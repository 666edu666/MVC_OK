using PracticasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Helper
{
    public class HelperVideo
    {

        public List<Video> VideosYoutube()
        {
            Video v1 = new Video("SXUJGlXxKSI", "Michelle Jenner");
            Video v2 = new Video("wjGtMgTlJa0", "Zahara");
            Video v3 = new Video("5saPAlr0SBA", "Laura Pausini");

            List<Video> listaVideos = new List<Video>();
            listaVideos.Add(v1);
            listaVideos.Add(v2);
            listaVideos.Add(v3);

            return listaVideos;

        }
        public String GetCodigoHTMLVideo(String cod)
        {
            String html = "<iframe width='560' height='315' src='https://www.youtube.com/embed/";
                        
            html += cod;
            html += "' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";

            return html;

        }
    }
}