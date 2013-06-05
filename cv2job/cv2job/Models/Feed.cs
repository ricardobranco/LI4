using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Feed
    {
        public Feed()
        {
            Data = DateTime.Now;
        }

        public int FeedID { get; set; }
        public string Imagem { get; set; }
        public string Identidade { get; set; }
        public int Tipo { get; set; }  //1 utilizador 2 anuncio 3 corporação
        public int AutorID { get; set; }
        public DateTime Data {get; set;}
        public string Descricao { get; set; }
    
    }
}