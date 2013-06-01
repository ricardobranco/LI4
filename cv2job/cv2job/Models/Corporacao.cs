using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cv2job.Models
{   
    

    [Table("Corporacoes")]
    public class Corporacao
    {
        public Corporacao()
        {
            this.Seguidores = new List<Utilizador>();
            this.Colaboradores = new List<Utilizador>();
            this.Anuncios = new List<Anuncio>();
        }
        

        [Key]
        public int CorpID { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Sector { get; set; }

        public String Website { get; set; }
        public String Pais { get; set; }
        public String CodPostal { get; set; }
        public String Morada { get; set; }
        public String Cidade { get; set; }
        public String Email { get; set; }
        public String Contacto { get; set; }
        public String PathLogo { get; set; }


        public virtual ICollection<Utilizador> Seguidores { get; set; }
        public virtual ICollection<Utilizador> Colaboradores { get; set; }
        public virtual ICollection<Anuncio> Anuncios { get; set; }

        
    
    }


}