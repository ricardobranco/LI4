namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarCorpWeb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Corporacoes", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Corporacoes", "Website");
        }
    }
}
