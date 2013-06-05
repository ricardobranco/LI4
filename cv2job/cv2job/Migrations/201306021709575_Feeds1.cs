namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feeds1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feeds", "AutorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Feeds", "Imagem", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feeds", "Imagem", c => c.String());
            DropColumn("dbo.Feeds", "AutorID");
        }
    }
}
