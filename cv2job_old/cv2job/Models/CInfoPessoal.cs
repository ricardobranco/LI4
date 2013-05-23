using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class CInfoPessoal
    {
        public int ID { get; set; }
        public String Sexo{get; set;}
        public String Proficao{ get; set; }
        public String EmpregoPretendido{ get; set; }
        public String EstudaEM { get; set; }
    }
}

