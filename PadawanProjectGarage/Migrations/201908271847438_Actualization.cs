namespace PadawanProjectGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "CodigoColaborador_ColaboradorId", "dbo.Colaboradors");
            DropForeignKey("dbo.Locacaos", "CodigoPeriodo_PeriodoID", "dbo.PeriodoLocacaos");
            DropForeignKey("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "TermoDeLocacao_TermoID", "dbo.TermoDeLocacaos");
            DropIndex("dbo.Locacaos", new[] { "CodigoColaborador_ColaboradorId" });
            DropIndex("dbo.Locacaos", new[] { "CodigoPeriodo_PeriodoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoTipo_TipoVeiculoID" });
            DropIndex("dbo.Locacaos", new[] { "TermoDeLocacao_TermoID" });
            AddColumn("dbo.Colaboradors", "OfereceCarona", c => c.Boolean(nullable: false));
            AddColumn("dbo.Colaboradors", "ResideFora", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Locacaos", "CodigoColaborador_ColaboradorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "CodigoPeriodo_PeriodoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "TermoDeLocacao_TermoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "CodigoColaborador_ColaboradorId");
            CreateIndex("dbo.Locacaos", "CodigoPeriodo_PeriodoID");
            CreateIndex("dbo.Locacaos", "CodigoTipo_TipoVeiculoID");
            CreateIndex("dbo.Locacaos", "TermoDeLocacao_TermoID");
            AddForeignKey("dbo.Locacaos", "CodigoColaborador_ColaboradorId", "dbo.Colaboradors", "ColaboradorId", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "CodigoPeriodo_PeriodoID", "dbo.PeriodoLocacaos", "PeriodoID", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes", "TipoVeiculoID", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "TermoDeLocacao_TermoID", "dbo.TermoDeLocacaos", "TermoID", cascadeDelete: true);
            DropColumn("dbo.Colaboradors", "Carona");
            DropColumn("dbo.Colaboradors", "OutroMunicipio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Colaboradors", "OutroMunicipio", c => c.Boolean(nullable: false));
            AddColumn("dbo.Colaboradors", "Carona", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Locacaos", "TermoDeLocacao_TermoID", "dbo.TermoDeLocacaos");
            DropForeignKey("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CodigoPeriodo_PeriodoID", "dbo.PeriodoLocacaos");
            DropForeignKey("dbo.Locacaos", "CodigoColaborador_ColaboradorId", "dbo.Colaboradors");
            DropIndex("dbo.Locacaos", new[] { "TermoDeLocacao_TermoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoTipo_TipoVeiculoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoPeriodo_PeriodoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoColaborador_ColaboradorId" });
            AlterColumn("dbo.Locacaos", "TermoDeLocacao_TermoID", c => c.Int());
            AlterColumn("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", c => c.Int());
            AlterColumn("dbo.Locacaos", "CodigoPeriodo_PeriodoID", c => c.Int());
            AlterColumn("dbo.Locacaos", "CodigoColaborador_ColaboradorId", c => c.Int());
            DropColumn("dbo.Colaboradors", "ResideFora");
            DropColumn("dbo.Colaboradors", "OfereceCarona");
            CreateIndex("dbo.Locacaos", "TermoDeLocacao_TermoID");
            CreateIndex("dbo.Locacaos", "CodigoTipo_TipoVeiculoID");
            CreateIndex("dbo.Locacaos", "CodigoPeriodo_PeriodoID");
            CreateIndex("dbo.Locacaos", "CodigoColaborador_ColaboradorId");
            AddForeignKey("dbo.Locacaos", "TermoDeLocacao_TermoID", "dbo.TermoDeLocacaos", "TermoID");
            AddForeignKey("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes", "TipoVeiculoID");
            AddForeignKey("dbo.Locacaos", "CodigoPeriodo_PeriodoID", "dbo.PeriodoLocacaos", "PeriodoID");
            AddForeignKey("dbo.Locacaos", "CodigoColaborador_ColaboradorId", "dbo.Colaboradors", "ColaboradorId");
        }
    }
}
