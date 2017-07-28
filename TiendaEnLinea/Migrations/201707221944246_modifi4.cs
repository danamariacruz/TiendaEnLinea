namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ImagenUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ImagenUrl");
        }
    }
}
