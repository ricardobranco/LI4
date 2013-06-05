using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Home
    {
        public LoginModel Loginmodel { get; set; }
        public IEnumerable<Utilizador> Utilizador { get; set; }
        public IEnumerable<Feed> Feeds { get; set; }

       }
}