using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    [Table("Anuncios")]
    public class Anuncio
    {
        public Anuncio()
        {
            this.Criado = DateTime.Now;
            this.Seguidores = new List<Utilizador>();
            
        }

        [Key]
        public int AnuncioID { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Cargo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CorporacaoID { get; set; }
        public virtual Corporacao Corporacao { get; set; }
        public virtual ICollection<Utilizador> Seguidores { get; set;}
        public String Descricao { get; set; }
        public String Funcao { get; set; }
        public DateTime Criado { get; set; }
        public virtual Utilizador Criador { get; set; }
        public string Experiencia { get; set;}
        public string Tipo { get; set; }
        public string Requisitos { get; set; }
    }
} 