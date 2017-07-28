namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "Categorias_CategoriaId", newName: "categoria_CategoriaId");
            RenameIndex(table: "dbo.Items", name: "IX_Categorias_CategoriaId", newName: "IX_categoria_CategoriaId");
            AddColumn("dbo.Items", "producer_ProducerID", c => c.Int());
            CreateIndex("dbo.Items", "producer_ProducerID");
            AddForeignKey("dbo.Items", "producer_ProducerID", "dbo.Producers", "ProducerID");
            DropColumn("dbo.Items", "IdProducer");
            DropColumn("dbo.Items", "IdCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "IdCategoria", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "IdProducer", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "producer_ProducerID", "dbo.Producers");
            DropIndex("dbo.Items", new[] { "producer_ProducerID" });
            DropColumn("dbo.Items", "producer_ProducerID");
            RenameIndex(table: "dbo.Items", name: "IX_categoria_CategoriaId", newName: "IX_Categorias_CategoriaId");
            RenameColumn(table: "dbo.Items", name: "categoria_CategoriaId", newName: "Categorias_CategoriaId");
        }
    }
}
