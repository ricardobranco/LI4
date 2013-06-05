using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Trabalho
    {
        [Key]
        public int TrabalhoID { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim {get; set;}
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Local { get; set; }
        public String Cargo { get; set; }
         
    }
}