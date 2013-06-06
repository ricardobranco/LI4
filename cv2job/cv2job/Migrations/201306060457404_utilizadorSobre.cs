namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorSobre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Sobre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "Sobre");
        }
    }
}
