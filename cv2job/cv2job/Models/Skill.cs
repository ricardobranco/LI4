using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cv2job.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        [Required(ErrorMessage="Campo Obrigatório")]
        public String SkillName { get; set; }
        public float SkillSize { get; set; }
    }
}