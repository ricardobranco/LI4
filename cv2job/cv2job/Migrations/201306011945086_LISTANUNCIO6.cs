namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnuncioUtilizadors", "Anuncio_AnuncioID", "dbo.Anuncios");
            DropForeignKey("dbo.AnuncioUtilizadors", "Utilizador_UserId", "dbo.Utilizadores");
            DropIndex("dbo.AnuncioUtilizadors", new[] { "Anuncio_AnuncioID" });
            DropIndex("dbo.AnuncioUtilizadors", new[] { "Utilizador_UserId" });
            AddColumn("dbo.Utilizadores", "Anuncio_AnuncioID", c => c.Int());
            AddColumn("dbo.Anuncios", "Utilizador_UserId", c => c.Int());
            AddColumn("dbo.Anuncios", "Utilizador_UserId1", c => c.Int());
            AddForeignKey("dbo.Utilizadores", "Anuncio_AnuncioID", "dbo.Anuncios", "AnuncioID");
            AddForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores", "UserId");
            AddForeignKey("dbo.Anuncios", "Utilizador_UserId1", "dbo.Utilizadores", "UserId");
            CreateIndex("dbo.Utilizadores", "Anuncio_AnuncioID");
            CreateIndex("dbo.Anuncios", "Utilizador_UserId");
            CreateIndex("dbo.Anuncios", "Utilizador_UserId1");
            DropTable("dbo.AnuncioUtilizadors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AnuncioUtilizadors",
                c => new
                    {
                        Anuncio_AnuncioID = c.Int(nullable: false),
                        Utilizador_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anuncio_AnuncioID, t.Utilizador_UserId });
            
            DropIndex("dbo.Anuncios", new[] { "Utilizador_UserId1" });
            DropIndex("dbo.Anuncios", new[] { "Utilizador_UserId" });
            DropIndex("dbo.Utilizadores", new[] { "Anuncio_AnuncioID" });
            DropForeignKey("dbo.Anuncios", "Utilizador_UserId1", "dbo.Utilizadores");
            DropForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Utilizadores", "Anuncio_AnuncioID", "dbo.Anuncios");
            DropColumn("dbo.Anuncios", "Utilizador_UserId1");
            DropColumn("dbo.Anuncios", "Utilizador_UserId");
            DropColumn("dbo.Utilizadores", "Anuncio_AnuncioID");
            CreateIndex("dbo.AnuncioUtilizadors", "Utilizador_UserId");
            CreateIndex("dbo.AnuncioUtilizadors", "Anuncio_AnuncioID");
            AddForeignKey("dbo.AnuncioUtilizadors", "Utilizador_UserId", "dbo.Utilizadores", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.AnuncioUtilizadors", "Anuncio_AnuncioID", "dbo.Anuncios", "AnuncioID", cascadeDelete: true);
        }
    }
}
