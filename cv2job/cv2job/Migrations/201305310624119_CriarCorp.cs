namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarCorp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Corporacoes", "Pais", c => c.String());
            AddColumn("dbo.Corporacoes", "CodPostal", c => c.String());
            AddColumn("dbo.Corporacoes", "Morada", c => c.String());
            AddColumn("dbo.Corporacoes", "Cidade", c => c.String());
            AddColumn("dbo.Corporacoes", "Email", c => c.String());
            AddColumn("dbo.Corporacoes", "Contacto", c => c.String());
            AddColumn("dbo.Corporacoes", "PathLogo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Corporacoes", "PathLogo");
            DropColumn("dbo.Corporacoes", "Contacto");
            DropColumn("dbo.Corporacoes", "Email");
            DropColumn("dbo.Corporacoes", "Cidade");
            DropColumn("dbo.Corporacoes", "Morada");
            DropColumn("dbo.Corporacoes", "CodPostal");
            DropColumn("dbo.Corporacoes", "Pais");
        }
    }
}
