namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mensagem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensagems", "Utilizador_UserId1", "dbo.Utilizadores");
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UserId1" });
            DropColumn("dbo.Mensagems", "Utilizador_UserId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagems", "Utilizador_UserId1", c => c.Int());
            CreateIndex("dbo.Mensagems", "Utilizador_UserId1");
            AddForeignKey("dbo.Mensagems", "Utilizador_UserId1", "dbo.Utilizadores", "UserId");
        }
    }
}
