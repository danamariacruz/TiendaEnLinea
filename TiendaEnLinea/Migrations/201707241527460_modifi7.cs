namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producers", "CategoriaID_CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Producers", "CategoriaID_CategoriaId");
            AddForeignKey("dbo.Producers", "CategoriaID_CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producers", "CategoriaID_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Producers", new[] { "CategoriaID_CategoriaId" });
            DropColumn("dbo.Producers", "CategoriaID_CategoriaId");
        }
    }
}
