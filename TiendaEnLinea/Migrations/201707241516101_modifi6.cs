namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaVentas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        IdVentas_VentaID = c.Int(),
                        ProductorID_ProducerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ventas", t => t.IdVentas_VentaID)
                .ForeignKey("dbo.Producers", t => t.ProductorID_ProducerID)
                .Index(t => t.IdVentas_VentaID)
                .Index(t => t.ProductorID_ProducerID);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        DiaVenta = c.DateTime(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VentaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListaVentas", "ProductorID_ProducerID", "dbo.Producers");
            DropForeignKey("dbo.ListaVentas", "IdVentas_VentaID", "dbo.Ventas");
            DropIndex("dbo.ListaVentas", new[] { "ProductorID_ProducerID" });
            DropIndex("dbo.ListaVentas", new[] { "IdVentas_VentaID" });
            DropTable("dbo.Ventas");
            DropTable("dbo.ListaVentas");
        }
    }
}
