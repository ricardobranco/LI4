using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Morada
    {
        public String numero { get; set; }
        public String nomeRua { get; set; }
        public String localidade { get; set; }
        public String codPost { get; set; }
        public String distrito { get; set; }
        public String pais { get; set; }
    }
}
