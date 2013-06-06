namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorApelido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Apelido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "Apelido");
        }
    }
}
