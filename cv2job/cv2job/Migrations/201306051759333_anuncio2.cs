namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncio2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "Requisitos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "Requisitos");
        }
    }
}
