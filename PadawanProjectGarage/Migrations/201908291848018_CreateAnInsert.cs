namespace PadawanProjectGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAnInsert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "CordoVeiculoFK", "dbo.CordoVeiculoes");
            DropForeignKey("dbo.Locacaos", "MarcaFK", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "ModeloFK", "dbo.Modeloes");
            DropIndex("dbo.Locacaos", new[] { "MarcaFK" });
            DropIndex("dbo.Locacaos", new[] { "ModeloFK" });
            DropIndex("dbo.Locacaos", new[] { "CordoVeiculoFK" });
            AlterColumn("dbo.Locacaos", "MarcaFK", c => c.Int());
            AlterColumn("dbo.Locacaos", "ModeloFK", c => c.Int());
            AlterColumn("dbo.Locacaos", "CordoVeiculoFK", c => c.Int());
            CreateIndex("dbo.Locacaos", "MarcaFK");
            CreateIndex("dbo.Locacaos", "ModeloFK");
            CreateIndex("dbo.Locacaos", "CordoVeiculoFK");
            AddForeignKey("dbo.Locacaos", "CordoVeiculoFK", "dbo.CordoVeiculoes", "CorId");
            AddForeignKey("dbo.Locacaos", "MarcaFK", "dbo.Marcas", "MarcaID");
            AddForeignKey("dbo.Locacaos", "ModeloFK", "dbo.Modeloes", "ModeloID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "ModeloFK", "dbo.Modeloes");
            DropForeignKey("dbo.Locacaos", "MarcaFK", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "CordoVeiculoFK", "dbo.CordoVeiculoes");
            DropIndex("dbo.Locacaos", new[] { "CordoVeiculoFK" });
            DropIndex("dbo.Locacaos", new[] { "ModeloFK" });
            DropIndex("dbo.Locacaos", new[] { "MarcaFK" });
            AlterColumn("dbo.Locacaos", "CordoVeiculoFK", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "ModeloFK", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "MarcaFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "CordoVeiculoFK");
            CreateIndex("dbo.Locacaos", "ModeloFK");
            CreateIndex("dbo.Locacaos", "MarcaFK");
            AddForeignKey("dbo.Locacaos", "ModeloFK", "dbo.Modeloes", "ModeloID", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "MarcaFK", "dbo.Marcas", "MarcaID", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "CordoVeiculoFK", "dbo.CordoVeiculoes", "CorId", cascadeDelete: true);
        }
    }
}
