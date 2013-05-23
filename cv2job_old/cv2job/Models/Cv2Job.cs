using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Cv2Job
    {
    }
    public class Cv2JobDBContext : DbContext
    {
        public DbSet<Anuncio> Anuncios  { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
    }
}