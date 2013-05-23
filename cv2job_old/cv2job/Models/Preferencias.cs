using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Preferencias
    {
        public String Sexo { get; set; }
        public String Local { get; set; }
        public Habilitacoes hab { get; set; }
        public bool Desemp { get; set; }
        public int IdadeMax { get; set; }
    }
}
