using PracticasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasMVC.Helper
{
    public class HelperVimeo
    {
        public List<Video> VideosVimeo()
        {
            Video v1 = new Video("168673540", "Video 1");
            Video v2 = new Video("168673540", "Video2");
            Video v3 = new Video("168673540", "Video 3");

            List<Video> listaVideos = new List<Video>();
            listaVideos.Add(v1);
            listaVideos.Add(v2);
            listaVideos.Add(v3);

            return listaVideos;

        }

        public String GetCodigoHTMLVimeo(String cod)
        {
            String html = "<iframe src = 'https://player.vimeo.com/video/";

            html += cod;
            html += "'  width = '640' height = '360' frameborder = '0' webkitallowfullscreen mozallowfullscreen allowfullscreen ></ iframe > < p >< a href = 'https://vimeo.com/31787236' > PIX Id C</ a > from < a href = 'https://vimeo.com/beeldmotion' > BEELD.motion </ a > on < a href = 'https://vimeo.com' > Vimeo </ a >.</ p > ";

            return html;

        }

    }

    
}