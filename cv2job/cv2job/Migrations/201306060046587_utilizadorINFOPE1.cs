namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorINFOPE1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Utilizadores", "InfoP_ID", "dbo.InfoPessoals");
            DropIndex("dbo.Utilizadores", new[] { "InfoP_ID" });
            DropColumn("dbo.Utilizadores", "InfoE_LinguaMaterna");
            DropColumn("dbo.Utilizadores", "InfoE_SocSkills");
            DropColumn("dbo.Utilizadores", "InfoE_Org");
            DropColumn("dbo.Utilizadores", "InfoE_Aptencias");
            DropColumn("dbo.Utilizadores", "InfoE_TecSkills");
            DropColumn("dbo.Utilizadores", "InfoE_ComputerSkills");
            DropColumn("dbo.Utilizadores", "InfoE_ArtistSkills");
            DropColumn("dbo.Utilizadores", "InfoE_OthersSkills");
            DropColumn("dbo.Utilizadores", "InfoE_DriveLicence");
            DropColumn("dbo.Utilizadores", "InfoE_AddInfo");
            DropColumn("dbo.Utilizadores", "InfoE_Anexos");
            DropColumn("dbo.Utilizadores", "InfoE_Grid");
            DropColumn("dbo.Utilizadores", "InfoE_Outras");
            DropColumn("dbo.Utilizadores", "InfoP_ID");
            DropTable("dbo.InfoPessoals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InfoPessoals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddInfo = c.String(),
                        Tel = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Nacionalidade = c.String(),
                        Nascimento = c.String(),
                        Genero = c.String(),
                        PathFoto = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Utilizadores", "InfoP_ID", c => c.Int());
            AddColumn("dbo.Utilizadores", "InfoE_Outras", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_Grid", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_Anexos", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_AddInfo", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_DriveLicence", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_OthersSkills", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_ArtistSkills", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_ComputerSkills", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_TecSkills", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_Aptencias", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_Org", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_SocSkills", c => c.String());
            AddColumn("dbo.Utilizadores", "InfoE_LinguaMaterna", c => c.String());
            CreateIndex("dbo.Utilizadores", "InfoP_ID");
            AddForeignKey("dbo.Utilizadores", "InfoP_ID", "dbo.InfoPessoals", "ID");
        }
    }
}
