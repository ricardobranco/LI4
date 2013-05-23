using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Mensagem
    {
        public int ID { get; set; }
        public String Emissor { get; set; }
        public String Receptor { get; set; }
        public String Assunto { get; set; }
        public String CorpoMsg { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }

    }

}
