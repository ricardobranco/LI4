using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Educacao
    {
        [Key]
        public int EducacaoID { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Instituicao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}