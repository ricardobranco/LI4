using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    [Serializable]
    public class GeocoderLocation
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Latitude, Longitude);
        }
    }
}