namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "CorporacaoID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anuncios", "CorporacaoID");
        }
    }
}
