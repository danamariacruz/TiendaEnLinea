namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addordendetailorden : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Items", new[] { "categoria_CategoriaId" });
            RenameColumn(table: "dbo.Items", name: "categoria_CategoriaId", newName: "CategoriaId");
            AlterColumn("dbo.Items", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "CategoriaId");
            AddForeignKey("dbo.Items", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Items", new[] { "CategoriaId" });
            AlterColumn("dbo.Items", "CategoriaId", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "CategoriaId", newName: "categoria_CategoriaId");
            CreateIndex("dbo.Items", "categoria_CategoriaId");
            AddForeignKey("dbo.Items", "categoria_CategoriaId", "dbo.Categorias", "CategoriaId");
        }
    }
}
