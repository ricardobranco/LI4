using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Utilizador
    {
        public int ID { get; set; }
        public String Username { get; set; }
        private String Password;
        public String Nome { get; set; }
        public Morada Morad { get; set; }
        public String Nacionalidade { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public DateTime DataNascFund { get; set; }
        public DateTime DataReg { get; set; }
        public String Foto { get; set; } //E MELHOR POR O PATH<string> é mais eficiente

    }
}
