using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace cv2job.Models
{
    public class InfoPessoal
    {
        /// <summary>
        /// Classe de Informação Pessoal de um candidato
        /// 
        /// </summary>
        public int ID { get; set; }
        public String FirstName{ get; set; }
        public String LastName{ get; set; }
        public String AddInfo{ get; set; }
        public String Tel{ get; set; }
        public String Fax{ get; set; }
        public String Email{ get; set; }
        public String Nacionalidade{ get; set; }
        public String Nascimento{ get; set; }
        public String Genero{ get; set; }
        public String PathFoto{ get; set; }

        /// <summary>
        /// Contem as informações pessoais
        /// </summary>
        public InfoPessoal(){

            this.FirstName = "NA";
            this.LastName = "NA";
            this.AddInfo = "NA";
            this.Tel = "NA";
            this.Fax = "NA";
            this.Email = "NA";
            this.Nacionalidade = "NA";
            this.Nascimento = "NA";
            this.Genero = "NA";
            this.PathFoto = "NA";

        }


        private String Ocupado(String cont){
            if (cont.Equals("NA"))
            return "false";
            else
            return "true";
        }



        public String Estado (String campo){
            switch (campo)
            {
      

                case ("FirstName"):
                    return this.Ocupado(this.FirstName);
                    

                case ("LastName"):
                   return this.Ocupado(this.LastName);
                    

                case ("AddInfo"):
                    return this.Ocupado(this.AddInfo);
                    

                case("Tel"):
                    return this.Ocupado(this.Tel);
                    

                case("Fax"):
                    return this.Ocupado(this.Fax);
                    

                case("Email"):
                    return this.Ocupado(this.Email);
                    
                case("Nacionalidade"):
                    return this.Ocupado(this.Nacionalidade);
                    
                case("Nascimento"):
                    return this.Ocupado(this.Nascimento);
                    
                case("Genero"):
                    return this.Ocupado(this.Genero);
                    
                case ("PathFoto"):
                    return this.Ocupado(this.PathFoto);

                default:
                    Console.WriteLine("Invalid");
                    return "";
            }
            
        
        }

    }
}
