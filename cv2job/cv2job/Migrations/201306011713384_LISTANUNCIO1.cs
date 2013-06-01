namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores");
            DropIndex("dbo.Anuncios", new[] { "Utilizador_UserId" });
            CreateTable(
                "dbo.AnuncioUtilizadors",
                c => new
                    {
                        Anuncio_AnuncioID = c.Int(nullable: false),
                        Utilizador_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anuncio_AnuncioID, t.Utilizador_UserId })
                .ForeignKey("dbo.Anuncios", t => t.Anuncio_AnuncioID, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId, cascadeDelete: true)
                .Index(t => t.Anuncio_AnuncioID)
                .Index(t => t.Utilizador_UserId);
            
            DropColumn("dbo.Anuncios", "Utilizador_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncios", "Utilizador_UserId", c => c.Int());
            DropIndex("dbo.AnuncioUtilizadors", new[] { "Utilizador_UserId" });
            DropIndex("dbo.AnuncioUtilizadors", new[] { "Anuncio_AnuncioID" });
            DropForeignKey("dbo.AnuncioUtilizadors", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.AnuncioUtilizadors", "Anuncio_AnuncioID", "dbo.Anuncios");
            DropTable("dbo.AnuncioUtilizadors");
            CreateIndex("dbo.Anuncios", "Utilizador_UserId");
            AddForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores", "UserId");
        }
    }
}
