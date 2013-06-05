using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace cv2job.Shuffle
{
    public static class MyShuffle
    {

        public static ICollection Shuffle(ICollection c)
        {
            if (c == null || c.Count <= 1)
            {
                return c;
            }

            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider cRandom = new RNGCryptoServiceProvider();
            cRandom.GetBytes(bytes);

            int seed = BitConverter.ToInt32(bytes, 0);
            Random random = new Random(seed);

            ArrayList orig = new ArrayList(c);
            ArrayList randomized = new ArrayList(c.Count);
            for (int i = 0; i < c.Count; i++)
            {
                int index = random.Next(orig.Count);
                randomized.Add(orig[index]);
                orig.RemoveAt(index);
            }
            return randomized;
        }
    }
}