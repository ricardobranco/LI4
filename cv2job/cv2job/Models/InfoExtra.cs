using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv2job.Models
{
   public class InfoExtra
    {
        public String LinguaMaterna { get; set;}
        public List<String> LinguaExtra{get;set;}
        public String SocSkills{get;set;}
        public String Org{get;set;}
        public String Aptencias{get;set;}
        public String TecSkills { get; set; }
        public String ComputerSkills {get;set;}
        public String ArtistSkills {get;set;}
        public String OthersSkills { get; set; }
        public String DriveLicence {get;set;}
        public String AddInfo {get;set;}
        public String Anexos{get;set;}
        public String Grid { get; set; }
        public String Outras{get;set;}


        public InfoExtra() { 
        
        this.LinguaMaterna="NA";
        this.LinguaExtra=new List<String>();
        this.SocSkills="NA";
        this.Org="NA";
        this.Aptencias="NA";
        this.ComputerSkills="NA";
        this.ArtistSkills="NA";
        this.DriveLicence="NA";
        this.AddInfo="NA";
        this.Anexos="NA";
        this.Grid="NA";
        this.Outras="NA";
        
        }




        private String Ocupado(String cont)
        {
            if (cont == null)
                return "false";
            if (cont.Equals("NA"))
                return "false";
            else
                return "true";
        }







        public String Estado(String campo)
        {
            switch (campo)
            {

                case ("LinguaMaterna"):
                return this.Ocupado(this.LinguaMaterna);
               //Tratar conhecimentos de Lingua estrangeira que falta

                case("Org"):
                return this.Ocupado(this.Org);

                case ("SocSkils"):
                return this.Ocupado(this.SocSkills);

                case ("Aptencias"):
                return this.Ocupado(this.Aptencias);

                case("TecnicSkills"):
                return this.Ocupado(this.TecSkills);

                case ("ComputerSkills"):
                return this.Ocupado(this.ComputerSkills);

                case ("ArtistSkills"):
                return this.Ocupado(this.ArtistSkills);

                case("OtherSkills"):
                return this.Ocupado(this.OthersSkills);

                case ("DriveLicence"):
                return this.Ocupado(this.DriveLicence);
 
                case ("AddInfo"):
                return this.Ocupado(this.AddInfo);
                
                case ("Anexos"):
                return this.Ocupado(this.Anexos);
                
                case ("Grid"):
                return this.Ocupado(this.Grid);
                
                case ("Outras"):
                return this.Ocupado(this.Outras);
    
                default:
                    Console.WriteLine("Invalid");
                    return "";
            }


        }




    }

    

}
