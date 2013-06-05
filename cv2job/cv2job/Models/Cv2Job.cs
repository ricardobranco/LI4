using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Cv2jobContext : DbContext
    {
        public Cv2jobContext()
            : base("Cv2JobDBContext")
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Corporacao> Corporacoes { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Educacao> Educacaos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Feed> Feeds { get; set; }   
    }

}