namespace TiendaEnLinea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifi71 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListaVentas", "ProductorID_ProducerID", "dbo.Producers");
            DropForeignKey("dbo.ListaVentas", "IdVentas_VentaID", "dbo.Ventas");
            DropIndex("dbo.ListaVentas", new[] { "IdVentas_VentaID" });
            DropIndex("dbo.ListaVentas", new[] { "ProductorID_ProducerID" });
            RenameColumn(table: "dbo.ListaVentas", name: "IdVentas_VentaID", newName: "VentaId");
            AddColumn("dbo.ListaVentas", "ItemID", c => c.Int(nullable: false));
            AddColumn("dbo.ListaVentas", "itemID_ProductoID", c => c.Int());
            AlterColumn("dbo.ListaVentas", "VentaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ListaVentas", "VentaId");
            CreateIndex("dbo.ListaVentas", "itemID_ProductoID");
            AddForeignKey("dbo.ListaVentas", "itemID_ProductoID", "dbo.Items", "ProductoID");
            AddForeignKey("dbo.ListaVentas", "VentaId", "dbo.Ventas", "VentaID", cascadeDelete: true);
            DropColumn("dbo.ListaVentas", "ProductorID_ProducerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListaVentas", "ProductorID_ProducerID", c => c.Int());
            DropForeignKey("dbo.ListaVentas", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.ListaVentas", "itemID_ProductoID", "dbo.Items");
            DropIndex("dbo.ListaVentas", new[] { "itemID_ProductoID" });
            DropIndex("dbo.ListaVentas", new[] { "VentaId" });
            AlterColumn("dbo.ListaVentas", "VentaId", c => c.Int());
            DropColumn("dbo.ListaVentas", "itemID_ProductoID");
            DropColumn("dbo.ListaVentas", "ItemID");
            RenameColumn(table: "dbo.ListaVentas", name: "VentaId", newName: "IdVentas_VentaID");
            CreateIndex("dbo.ListaVentas", "ProductorID_ProducerID");
            CreateIndex("dbo.ListaVentas", "IdVentas_VentaID");
            AddForeignKey("dbo.ListaVentas", "IdVentas_VentaID", "dbo.Ventas", "VentaID");
            AddForeignKey("dbo.ListaVentas", "ProductorID_ProducerID", "dbo.Producers", "ProducerID");
        }
    }
}
