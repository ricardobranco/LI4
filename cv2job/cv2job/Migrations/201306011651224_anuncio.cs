namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anuncio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            AddColumn("dbo.Anuncios", "Utilizador_UserId", c => c.Int());
            AddColumn("dbo.Corporacoes", "Utilizador_UserId", c => c.Int());
            AddColumn("dbo.Corporacoes", "Utilizador_UserId1", c => c.Int());
            AlterColumn("dbo.Anuncios", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Anuncios", "Corporacao_CorpID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Corporacoes", "Utilizador_UserId", "dbo.Utilizadores", "UserId");
            AddForeignKey("dbo.Corporacoes", "Utilizador_UserId1", "dbo.Utilizadores", "UserId");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID", cascadeDelete: true);
            AddForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores", "UserId");
            CreateIndex("dbo.Corporacoes", "Utilizador_UserId");
            CreateIndex("dbo.Corporacoes", "Utilizador_UserId1");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
            CreateIndex("dbo.Anuncios", "Utilizador_UserId");
            DropColumn("dbo.Anuncios", "Descricao");
            DropColumn("dbo.Anuncios", "InfoAdiconal");
            DropColumn("dbo.Anuncios", "TipoEmprego");
            DropColumn("dbo.Anuncios", "eRenumerado");
            DropColumn("dbo.Anuncios", "Renumeracao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncios", "Renumeracao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Anuncios", "eRenumerado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Anuncios", "TipoEmprego", c => c.String());
            AddColumn("dbo.Anuncios", "InfoAdiconal", c => c.String());
            AddColumn("dbo.Anuncios", "Descricao", c => c.String());
            DropIndex("dbo.Anuncios", new[] { "Utilizador_UserId" });
            DropIndex("dbo.Anuncios", new[] { "Corporacao_CorpID" });
            DropIndex("dbo.Corporacoes", new[] { "Utilizador_UserId1" });
            DropIndex("dbo.Corporacoes", new[] { "Utilizador_UserId" });
            DropForeignKey("dbo.Anuncios", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes");
            DropForeignKey("dbo.Corporacoes", "Utilizador_UserId1", "dbo.Utilizadores");
            DropForeignKey("dbo.Corporacoes", "Utilizador_UserId", "dbo.Utilizadores");
            AlterColumn("dbo.Anuncios", "Corporacao_CorpID", c => c.Int());
            AlterColumn("dbo.Anuncios", "Titulo", c => c.String());
            DropColumn("dbo.Corporacoes", "Utilizador_UserId1");
            DropColumn("dbo.Corporacoes", "Utilizador_UserId");
            DropColumn("dbo.Anuncios", "Utilizador_UserId");
            CreateIndex("dbo.Anuncios", "Corporacao_CorpID");
            AddForeignKey("dbo.Anuncios", "Corporacao_CorpID", "dbo.Corporacoes", "CorpID");
        }
    }
}
