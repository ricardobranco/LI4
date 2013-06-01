namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Criado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "Criado");
        }
    }
}
