namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        IdProducer = c.Int(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        Categorias_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Categorias", t => t.Categorias_CategoriaId)
                .Index(t => t.Categorias_CategoriaId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProducerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Categorias_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Items", new[] { "Categorias_CategoriaId" });
            DropTable("dbo.Producers");
            DropTable("dbo.Items");
            DropTable("dbo.Categorias");
        }
    }
}
