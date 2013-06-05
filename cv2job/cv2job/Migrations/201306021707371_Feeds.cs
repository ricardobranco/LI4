namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feeds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        FeedID = c.Int(nullable: false, identity: true),
                        Imagem = c.String(),
                        Identidade = c.String(),
                        Tipo = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.FeedID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feeds");
        }
    }
}
