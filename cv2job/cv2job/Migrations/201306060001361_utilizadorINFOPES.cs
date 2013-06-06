namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorINFOPES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Morada", c => c.String());
            AddColumn("dbo.Utilizadores", "CodPostal", c => c.String());
            AddColumn("dbo.Utilizadores", "Cidade", c => c.String());
            AddColumn("dbo.Utilizadores", "Nacionalidade", c => c.String());
            AddColumn("dbo.Utilizadores", "Pais", c => c.String());
            AddColumn("dbo.Utilizadores", "Sexo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "Sexo");
            DropColumn("dbo.Utilizadores", "Pais");
            DropColumn("dbo.Utilizadores", "Nacionalidade");
            DropColumn("dbo.Utilizadores", "Cidade");
            DropColumn("dbo.Utilizadores", "CodPostal");
            DropColumn("dbo.Utilizadores", "Morada");
        }
    }
}
