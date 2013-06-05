using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2job.Models
{
    class Candidato
    {
		public String username{get;set;}
        public InfoPessoal pessoal { get; set; }
        public InfoExtra info { get; set; }


        public Candidato(String nameuser,InfoPessoal infoP ,InfoExtra infoE) {
			this.username=nameuser;
            this.pessoal = infoP;
            this.info = infoE;
        }
    }
}
