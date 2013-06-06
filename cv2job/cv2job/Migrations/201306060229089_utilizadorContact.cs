namespace cv2job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilizadorContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilizadores", "Fax", c => c.String());
            AddColumn("dbo.Utilizadores", "Contacto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilizadores", "Contacto");
            DropColumn("dbo.Utilizadores", "Fax");
        }
    }
}
