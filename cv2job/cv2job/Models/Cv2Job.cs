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

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
    }

}