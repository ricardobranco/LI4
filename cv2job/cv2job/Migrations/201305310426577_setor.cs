namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Corporacoes", "Sector", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Corporacoes", "Sector");
        }
    }
}
