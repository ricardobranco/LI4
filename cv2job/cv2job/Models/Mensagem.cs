using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cv2job.Models
{
    public class Mensagem
    {
        public Mensagem()
        {
            this.Lida = false;
            this.DataEnvio = DateTime.Now;
        }
        [Key]
        public int MensagemID { get; set; }
        public virtual Utilizador Emissor { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public virtual Utilizador Receptor { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Assunto { get; set; }
        public String CorpoMsg { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }

    }

}
