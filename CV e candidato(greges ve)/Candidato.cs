using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Candidato
    {
		public String username{get;set;};
        public InfoPessoal pessoal { get; set; }
        public InfoExtra info { get; set; }


        public Candidato(String nameuser) {
			this.username=nameuser;
            this.pessoal = new InfoPessoal();
            this.info = new InfoExtra();
        }
    }
}
