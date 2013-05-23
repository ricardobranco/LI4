using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Empregador : Utilizador
    {
        public Preferencias pref { get; set; }
        public float SalMax { get; set; }
        public String AreaEmp { get; set; }
        public String DescEmp { get; set; }
    }
}
