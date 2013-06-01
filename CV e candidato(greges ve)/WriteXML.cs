using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace ConsoleApplication4
{
    class WriteXML
    {
        public Candidato person {get;set;}
        public System.IO.TextWriter t { get; set; }


        /// <summary>
        /// Contructor com o path do ficheiro out.
        /// </summary>
        /// <param name="pathfile">PathOut</param>
        public WriteXML(String pathfile,Candidato cd) {

            
            if (!System.IO.File.Exists(pathfile))
                System.IO.File.Create(pathfile).Close();

            this.t = System.IO.File.AppendText(pathfile);
            this.person = cd;
        
        
        }
        
        
        
        /// <summary>
        /// Cabeçalho do XMLCV
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private void Cabec()
        {
            t.WriteLine("<?xml-stylesheet href=\"http://europass.cedefop.europa.eu/xml/cv_en_GB.xsl\" type=\"text/xsl\"?>");
            t.WriteLine("<europass:learnerinfo xsi:schemaLocation=\"http://europass.cedefop.europa.eu/Europass/V2.0 http://europass.cedefop.europa.eu/xml/EuropassSchema_V2.0.xsd\" xmlns:europass=\"http://europass.cedefop.europa.eu/Europass/V2.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" locale=\"en_GB\">");

            t.WriteLine("<docinfo>");
		    t.WriteLine("<issuedate>2013-05-28T10:58:57+01:00</issuedate>");
		    t.WriteLine("<xsdversion>V2.0</xsdversion>");
		    t.WriteLine("<comment>Automatically generated Europass CV</comment>");
		    t.WriteLine("</docinfo>");

            t.WriteLine("<prefs>");
        }






        /// <summary>
        /// Função para a converção da imagem
        /// </summary>
        /// <param name="image"></param>
        /// <returns>StringNaBase64</returns>
        private string ImageToBase64String(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
        }



      
        ////////////////////////////////////Start of Field///////////////////////////////////////
       
        private void FieldFirstLastName()
        {
            this.t.WriteLine("<field name=\"step1.firstName\" before=\"step1.lastName\"></field>");
        }

        private void FielfAddressInfo() {
            t.WriteLine("<field name=\"step1.addressInfo\" keep=\"" +this.person.pessoal.Estado("AddInfo")+ "\"></field>");

        }

        private void FielTelephone() {
            t.WriteLine("<field name=\"step1.telephone\" keep=\"" + this.person.pessoal.Estado("Tel") + "\"></field>");
            t.WriteLine("<field name=\"step1.mobile\" keep=\"" + this.person.pessoal.Estado("Tel") + "\"></field>");
        }

        private void FielFax() {
            t.WriteLine("<field name=\"step1.fax\" keep=\"" + this.person.pessoal.Estado("Fax") + "\"></field>");
        }

        private void FielEmail() {
            t.WriteLine("<field name=\"step1.email\" keep=\"" + this.person.pessoal.Estado("Email") + "\"></field>");
        }

        private void FielNationality() {
            t.WriteLine("<field name=\"step1.nationality\" keep=\"" + this.person.pessoal.Estado("Nacionalidade") + "\"></field>");
               
        }

        private void FielbirthDate() {
            t.WriteLine("<field name=\"step1.birthDate\" keep=\"" + this.person.pessoal.Estado("Nascimento") + "\" format=\"/text/long\"></field>");
        }

        private void FielGener() {
            t.WriteLine("<field name=\"step1.gender\" keep=\"" + this.person.pessoal.Estado("Genero") + "\"></field>");
        }

        private void FielPhoto() {
            t.WriteLine("<field name=\"step1.photo\" keep=\"" + this.person.pessoal.Estado("PathFoto") + "\"></field>");
        }


        //Meter a falso
        private void FielToChange() { 
            t.WriteLine("<field name=\"step1.application.label\" keep=\"false\"></field>");
            /*
		    //t.WriteLine("<field format=\"/numeric/medium\" name=\"step3List[0].period\"></field>");
		   */
            t.WriteLine("<field name=\"step3List\" keep=\"false\" before=\"step4List\"></field>");
            /*
		    t.WriteLine("<field keep=\"false\" name=\"step3List[0].company.sector.label\"></field>");
		    t.WriteLine("<field keep=\"false\" name=\"step3List[0].company.addressInfo\"></field>");
		    t.WriteLine("<field keep=\"false\" name=\"step3List[0].company.name\"></field>");
		    t.WriteLine("<field keep=\"false\" name=\"step3List[0].activities\"></field>");
		    t.WriteLine("<field keep=\"false\" name=\"step3List[0].position.label\"></field>");*/
		    t.WriteLine("<field name=\"step4List\" keep=\"false\"></field>");
           /* t.WriteLine("<field keep=\"false\" name=\"step4List[0].level.label\"></field>");
            t.WriteLine("<field keep=\"false\" name=\"step4List[0].educationalOrg.addressInfo\"></field>");
            t.WriteLine("<field keep=\"false\" name=\"step4List[0].educationalOrg.name\"></field>");
            t.WriteLine("<field keep=\"false\" name=\"step4List[0].skills\"></field>");
		    t.WriteLine("<field keep=\"false\" name=\"step4List[0].title\"></field>");*/
        }

        private void FielMotherLinguage() {
            t.WriteLine("<field name=\"step5.motherLanguages\" keep=\"" +this.person.info.Estado("LinguaMaterna")+ "\"></field>");
        }

        //Falta elementos da lista
        private void FielforeignLanguage() {
            t.WriteLine("<field name=\"step5.foreignLanguageList\" keep=\"false\"></field>");	
		//Par a lista de linguas<field keep="true" name="step5.foreignLanguageList[0]"></field>
        }

        private void FielSocialSkills() {
            t.WriteLine("<field name=\"step6.socialSkills\" keep=\"" + this.person.info.Estado("SocSkils") + "\"></field>");
        }

        private void FielOrganisationalSkills() {
            t.WriteLine("<field name=\"step6.organisationalSkills\" keep=\"" + this.person.info.Estado("Aptencias")+ "\"></field>");
        }

        private void FielTecnicalSkills() {
            t.WriteLine("<field name=\"step6.technicalSkills\" keep=\"" + this.person.info.Estado("TecnicSkills") + "\"></field>");

        }

        private void FielComputerSkills() {
            t.WriteLine("<field name=\"step6.computerSkills\" keep=\"" + this.person.info.Estado("ComputerSkills") + "\"></field>");
        }

        private void FielArtit(){
             t.WriteLine("<field name=\"step6.artisticSkills\" keep=\"" + this.person.info.Estado("ArtistSkills") + "\"></field>");
        }

        private void FielOtherSkills() {
            t.WriteLine("<field name=\"step6.otherSkills\" keep=\"" + this.person.info.Estado("OtherSkills") + "\"></field>");
        }

        private void FielDriveLincences() { 
        t.WriteLine("<field name=\"step6.drivingLicences\" keep=\""+this.person.info.Estado("DriveLicence")+"\"></field>");
        }

        private void FielAddInfo() {
            t.WriteLine("<field name=\"step7.additionalInfo\" keep=\"" + this.person.info.Estado("AddInfo") + "\"></field>");
        }

        private void FielAnexos() {
            t.WriteLine("<field name=\"step7.annexes\" keep=\"" + this.person.info.Estado("Anexos") + "\"></field>");
        
        }

        private void Fielgrid() {
            t.WriteLine("<field name=\"grid\" keep=\"" + this.person.info.Estado("Grid") + "\"></field>");
            t.WriteLine("</prefs>");
        }



        ///////////////////////////END OF FIEL//////////////////////////////////////////////////

        //////////////////////////START IDENTIF//////////////////////////////////////////

        //Ente label Indetif
        private void Identificacao() {

            t.WriteLine("<identification>");
            if(this.person.pessoal.FirstName!="NA")
            t.WriteLine("<firstname>" + this.person.pessoal.FirstName + "</firstname>");
            if(this.person.pessoal.FirstName !="NA")
            t.WriteLine("<lastname>" + this.person.pessoal.LastName + "</lastname>");
            

            if(this.person.pessoal.Tel!="NA")
            {
                t.WriteLine("<contactinfo>");

                if(this.person.pessoal.Nacionalidade!="NA")
                {
                    t.WriteLine("<address>");
                    t.WriteLine("<addressLine>StreetNumber</addressLine><municipality>Cidade</municipality><postalCode>CodPostal</postalCode><country><label></label></country></address>");
                }
            
                if(this.person.pessoal.Tel!="NA")t.WriteLine("<telephone>"+this.person.pessoal.Tel+"</telephone>");
            
                if(this.person.pessoal.Fax!="NA")t.WriteLine("<fax>"+this.person.pessoal.Fax+"</fax>");
            
                if(this.person.pessoal.Tel!="NA")t.WriteLine("<mobile>"+this.person.pessoal.Tel+"</mobile>");
            
                if(this.person.pessoal.Email!="NA")t.WriteLine("<email>"+this.person.pessoal.Email+"</email>");
            
                t.WriteLine("</contactinfo>");
            }


            if(this.person.pessoal.Nascimento!="NA")
            {
                t.WriteLine("<demographics>");
                   t.WriteLine("<birthdate>"+this.person.pessoal.Nascimento+"</birthdate>");
                if(this.person.pessoal.Genero!="NA") t.WriteLine("<gender>"+this.person.pessoal.Genero+"</gender>");
                if(this.person.pessoal.Nacionalidade!="NA")t.WriteLine("<nationality><code>PT</code><label>Portuguese</label></nationality></demographics>");
            }

            if (this.person.pessoal.PathFoto!="NA") t.WriteLine("<photo type=\"JPEG\">" + this.ImageToBase64String(Image.FromFile(this.person.pessoal.PathFoto)) + "</photo>");

            t.WriteLine("</identification>");

        }




        public void ExtraId() { 
        t.WriteLine(" <application>");
		t.WriteLine("<label></label></application>");
	    t.WriteLine("<languagelist>");
		t.WriteLine("<language xsi:type=\"europass:mother\">");
		t.WriteLine("	<label></label></language></languagelist>");
	    t.WriteLine("<skilllist>");
		t.WriteLine("<skill type=\"social\"></skill>");
		t.WriteLine("<skill type=\"organisational\"></skill>");
		t.WriteLine("<skill type=\"technical\"></skill>");
		t.WriteLine("<skill type=\"computer\"></skill>");
		t.WriteLine("<skill type=\"artistic\"></skill>");
		t.WriteLine("<skill type=\"other\"></skill>");
		t.WriteLine("<structured-skill xsi:type=\"europass:driving\"></structured-skill></skilllist>");
	    t.WriteLine("<misclist>");
	    t.WriteLine("<misc type=\"additional\"></misc>");
	    t.WriteLine("<misc type=\"annexes\"></misc></misclist>");
        

        }
        
        
        //falta ajustar!!
        private void Extra() {
            //Pode ser uma lista.
            //t.WriteLine("<application><label>"+this.person.info.??+"</label></application>");
            

            //Work
	t.WriteLine("<workexperiencelist>");
    //se tiver elementos.
     t.WriteLine("<workexperience>");
		t.WriteLine("<period>");
				t.WriteLine("<from>");
					t.WriteLine("<year>2011</year>");
					t.WriteLine("<month>--04</month>");
					t.WriteLine("<day>---02</day>");
				t.WriteLine("</from>");
				
                t.WriteLine("<to>");
					t.WriteLine("<year>2011</year>");
					t.WriteLine("<month>--04</month>");
					t.WriteLine("<day>---04</day>");
				t.WriteLine("</to>");
			t.WriteLine("</period>)");
			t.WriteLine("<position>");
				t.WriteLine("<label>Tailoripo de Trabalho</label>");
			t.WriteLine("</position>");
			t.WriteLine("<activities>Responsabilidades</activities>");
			t.WriteLine("<employer>");
				t.WriteLine("<name>Empresa</name>");
				t.WriteLine("<address>");
					t.WriteLine("<addressLine>Morada da empresa</addressLine>");
					t.WriteLine("<municipality>cidada</municipality>");
					t.WriteLine("<postalCode>CodPost</postalCode>");
					t.WriteLine("<country>");
						t.WriteLine("label>Coun</label>");
					t.WriteLine("</country>");
				t.WriteLine("</address>");
				t.WriteLine("<sector>");
					t.WriteLine("<label>tipo de empre</label>");
				t.WriteLine("</sector>");
			t.WriteLine("</employer>");
		t.WriteLine("</workexperience>");
	t.WriteLine("</workexperiencelist>");



            //Education

            
t.WriteLine(" <education> "); 



t.WriteLine(" <period> "); 



t.WriteLine(" <from> ");
 


t.WriteLine(" <year> ");
 
t.WriteLine(" </year> ");
 


t.WriteLine(" <month> "); 

t.WriteLine(" </month> ");
 


t.WriteLine(" <day> ");
 
t.WriteLine(" </day> ");
 


t.WriteLine(" </from> "); 



t.WriteLine(" <to> "); 



t.WriteLine(" <year> ");
t.WriteLine(" </year> ");
t.WriteLine(" <month> ");
t.WriteLine(" </month> "); 
t.WriteLine(" <day> ");
t.WriteLine(" </day> ");
t.WriteLine(" </to> ");
t.WriteLine(" </period> "); 
t.WriteLine(" <title> "); 
t.WriteLine(" </title> "); 
t.WriteLine(" <skills> "); 
t.WriteLine(" </skills> "); 
t.WriteLine(" <organisation> ");
t.WriteLine(" <name> "); 
t.WriteLine(" </name> "); 

t.WriteLine(" <address> ");

t.WriteLine(" <addressLine> "); 

t.WriteLine(" </addressLine> "); 

t.WriteLine(" <municipality> "); 

t.WriteLine(" </municipality> "); 

t.WriteLine(" <postalCode> "); 
t.WriteLine(" </postalCode> "); 

t.WriteLine(" <country> "); 

t.WriteLine(" <label> ");
 
t.WriteLine(" </label> ");
 
t.WriteLine(" </country> ");
 
t.WriteLine(" </address> ");

t.WriteLine(" <type> "); 

t.WriteLine(" </type> ");
 
t.WriteLine(" </organisation> "); 

t.WriteLine(" <level> ");

t.WriteLine(" <label> "); 

t.WriteLine(" </label> "); 

t.WriteLine(" </level> "); 

t.WriteLine(" <educationalfield> ");


t.WriteLine(" <label> ");
 
t.WriteLine(" </label> "); 

t.WriteLine(" </educationalfield> ");
 
t.WriteLine(" </education> "); 



/*
            	<educationlist>
		<education>
			<period>
				<from>
					<year>2008</year>
					<month>--07</month>
					<day>---03</day>
				</from>
				<to>
					<year>2014</year>
					<month>--07</month>
					<day>---07</day>
				</to>
			</period>
			<title>Estudos de a</title>
			<skills>Que tipo de conhecimentos obtive</skills>
			<organisation>
				<name>Nome da instituição</name>
				<address>
					<addressLine>nr</addressLine>
					<municipality>Cis</municipality>
					<postalCode></postalCode>
					<country>
						<label></label>
					</country>
				</address>
				<type>tipo da instituição</type>
			</organisation>
			<level>
				<label></label>
			</level>
			<educationalfield>
				<label></label>
			</educationalfield>
		</education>
	</educationlist>*/
        
        }




        private void radape() {

            t.WriteLine("</europass:learnerinfo>"); 
        }


        public void WritetoXml() {

            this.Cabec();

            FieldFirstLastName();
            FielfAddressInfo();
            FielTelephone();
            FielFax();
            FielEmail();
            FielNationality();
            FielbirthDate();
            FielGener();
            FielPhoto();
            FielToChange();
            FielMotherLinguage();
            FielforeignLanguage();
            FielSocialSkills();
            FielOrganisationalSkills();
            FielTecnicalSkills();
            FielComputerSkills();
            FielArtit();
            FielOtherSkills();
            FielDriveLincences();
            FielAddInfo();
            FielAnexos();
            Fielgrid();
            Identificacao();
            ExtraId();
            radape();
            t.Close();
        
        }

	/* Para testar!
        static void Main(string[] args) {

            Candidato cd = new Candidato();

            cd.pessoal.FirstName="Luis";
            cd.pessoal.LastName = "Caseiro";
            cd.pessoal.AddInfo = "Gay";
            cd.pessoal.Tel = "912313";
            cd.pessoal.Fax = "9123";
            cd.pessoal.Email = "maiarib@gmail";
            cd.pessoal.Nacionalidade = "Portugues";
            cd.pessoal.Nascimento = "12-08-1991";
            cd.pessoal.Genero = "M";
            cd.pessoal.PathFoto = "C:\\CV\\p.jpg";

            WriteXML xml = new WriteXML("C:\\CV\\lixo.xml", cd);
            xml.WritetoXml();
        
        
        }
		
	*/
    }




        

        
 

}
