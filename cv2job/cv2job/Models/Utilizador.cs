using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    abstract class Utilizador
    {
        public String username { get; set; }
        public String nome { get; set; }
        public Morada morada { get; set; }
        public String telefone { get; set; }
        public String email { get; set; }
        public Byte[] foto { get; set; }
    }
}
