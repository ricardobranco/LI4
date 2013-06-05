namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        EmissorID = c.Int(nullable: false),
                        ReceptorID = c.Int(nullable: false),
                        Assunto = c.String(nullable: false),
                        CorpoMsg = c.String(),
                        DataEnvio = c.DateTime(nullable: false),
                        Lida = c.Boolean(nullable: false),
                        Utilizador_UserId = c.Int(),
                        Utilizador_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MensagemID)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId1)
                .Index(t => t.Utilizador_UserId)
                .Index(t => t.Utilizador_UserId1);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(nullable: false),
                        SkillSize = c.Single(nullable: false),
                        Utilizador_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId)
                .Index(t => t.Utilizador_UserId);
            
            CreateTable(
                "dbo.Educacaos",
                c => new
                    {
                        EducacaoID = c.Int(nullable: false, identity: true),
                        Instituicao = c.String(nullable: false),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                        Utilizador_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EducacaoID)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId)
                .Index(t => t.Utilizador_UserId);
            
            CreateTable(
                "dbo.Trabalhoes",
                c => new
                    {
                        TrabalhoID = c.Int(nullable: false, identity: true),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                        Local = c.String(nullable: false),
                        Cargo = c.String(),
                        Utilizador_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TrabalhoID)
                .ForeignKey("dbo.Utilizadores", t => t.Utilizador_UserId)
                .Index(t => t.Utilizador_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trabalhoes", new[] { "Utilizador_UserId" });
            DropIndex("dbo.Educacaos", new[] { "Utilizador_UserId" });
            DropIndex("dbo.Skills", new[] { "Utilizador_UserId" });
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UserId1" });
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UserId" });
            DropForeignKey("dbo.Trabalhoes", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Educacaos", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Skills", "Utilizador_UserId", "dbo.Utilizadores");
            DropForeignKey("dbo.Mensagems", "Utilizador_UserId1", "dbo.Utilizadores");
            DropForeignKey("dbo.Mensagems", "Utilizador_UserId", "dbo.Utilizadores");
            DropTable("dbo.Trabalhoes");
            DropTable("dbo.Educacaos");
            DropTable("dbo.Skills");
            DropTable("dbo.Mensagems");
        }
    }
}
