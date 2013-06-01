namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LISTANUNCIO8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anuncios", "Criado", c => c.DateTime(nullable: false));
            AddColumn("dbo.Anuncios", "Criador_UserId", c => c.Int());
            AddForeignKey("dbo.Anuncios", "Criador_UserId", "dbo.Utilizadores", "UserId");
            CreateIndex("dbo.Anuncios", "Criador_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Anuncios", new[] { "Criador_UserId" });
            DropForeignKey("dbo.Anuncios", "Criador_UserId", "dbo.Utilizadores");
            DropColumn("dbo.Anuncios", "Criador_UserId");
            DropColumn("dbo.Anuncios", "Criado");
        }
    }
}
