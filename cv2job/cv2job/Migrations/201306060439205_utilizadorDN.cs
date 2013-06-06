namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorDN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "DataNascimento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "DataNascimento");
        }
    }
}
