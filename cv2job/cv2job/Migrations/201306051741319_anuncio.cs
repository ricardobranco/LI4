namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "Experiencia", c => c.String());
            AddColumn("dbo.Anuncios", "Tipo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "Tipo");
            DropColumn("dbo.Anuncios", "Experiencia");
        }
    }
}
