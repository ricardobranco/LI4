namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorsite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "WebSite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "WebSite");
        }
    }
}
