using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Anuncio
    {
        public int ID { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public String InfoAdiconal { get; set; }
        public String TipoEmprego { get; set; }
        public bool eRenumerado { get; set; }
        public decimal Renumeracao { get; set; }

    }
} 