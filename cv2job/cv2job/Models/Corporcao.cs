using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cv2job.Models
{   
    [Table("Corporacoes")]
    public class Corporcao
    {
        [Key]
        public int CorpID { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public List<Utilizador> Seguidores { get; set; }
        public List<Utilizador> Colaboradores { get; set; }
        public List<Anuncio> Anuncios { get; set; } 
         
    }


}