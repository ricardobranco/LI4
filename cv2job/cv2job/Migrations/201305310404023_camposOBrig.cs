namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposOBrig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Corporacoes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Corporacoes", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Corporacoes", "Descricao", c => c.String());
            AlterColumn("dbo.Corporacoes", "Nome", c => c.String());
        }
    }
}
