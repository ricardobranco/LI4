using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Utilizador
    {
        public String username { get; set; }
        public String nome { get; set; }
        public Morada morada { get; set; }
        public String telefone { get; set; }
        public String email { get; set; }
        public String dataNascFund { get; set; }   // data de nascimento para candidato/empregador, data fundação para empregadores empresa.
        public Byte[] foto { get; set; } //E MELHOR POR O PATH<string> é mais eficiente

    }
}
