namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feeds2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feeds", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feeds", "Imagem", c => c.Int(nullable: false));
        }
    }
}
