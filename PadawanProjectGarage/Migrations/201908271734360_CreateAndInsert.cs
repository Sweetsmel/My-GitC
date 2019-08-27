namespace PadawanProjectGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAndInsert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        AdministradorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorId);
            
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        ColaboradorId = c.Int(nullable: false, identity: true),
                        CodigoColaborador = c.Int(nullable: false),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Idoso = c.Boolean(nullable: false),
                        Email = c.String(),
                        PCD = c.Boolean(nullable: false),
                        PeriodoNoturo = c.Boolean(nullable: false),
                        Carona = c.Boolean(nullable: false),
                        OutroMunicipio = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.CordoVeiculoes",
                c => new
                    {
                        CorId = c.Int(nullable: false, identity: true),
                        CodigoCor = c.Int(nullable: false),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CorId);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        LocacaoID = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        CodigoColaborador_ColaboradorId = c.Int(),
                        CodigoCor_CorId = c.Int(),
                        CodigoMarca_MarcaID = c.Int(),
                        CodigoModelo_ModeloID = c.Int(),
                        CodigoPeriodo_PeriodoID = c.Int(),
                        CodigoTipo_TipoVeiculoID = c.Int(),
                        TermoDeLocacao_TermoID = c.Int(),
                    })
                .PrimaryKey(t => t.LocacaoID)
                .ForeignKey("dbo.Colaboradors", t => t.CodigoColaborador_ColaboradorId)
                .ForeignKey("dbo.CordoVeiculoes", t => t.CodigoCor_CorId)
                .ForeignKey("dbo.Marcas", t => t.CodigoMarca_MarcaID)
                .ForeignKey("dbo.Modeloes", t => t.CodigoModelo_ModeloID)
                .ForeignKey("dbo.PeriodoLocacaos", t => t.CodigoPeriodo_PeriodoID)
                .ForeignKey("dbo.TipoVeiculoes", t => t.CodigoTipo_TipoVeiculoID)
                .ForeignKey("dbo.TermoDeLocacaos", t => t.TermoDeLocacao_TermoID)
                .Index(t => t.CodigoColaborador_ColaboradorId)
                .Index(t => t.CodigoCor_CorId)
                .Index(t => t.CodigoMarca_MarcaID)
                .Index(t => t.CodigoModelo_ModeloID)
                .Index(t => t.CodigoPeriodo_PeriodoID)
                .Index(t => t.CodigoTipo_TipoVeiculoID)
                .Index(t => t.TermoDeLocacao_TermoID);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        CodigoMarca = c.Int(nullable: false),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        CodigoTipo_TipoVeiculoID = c.Int(),
                    })
                .PrimaryKey(t => t.MarcaID)
                .ForeignKey("dbo.TipoVeiculoes", t => t.CodigoTipo_TipoVeiculoID)
                .Index(t => t.CodigoTipo_TipoVeiculoID);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        TipoVeiculoID = c.Int(nullable: false, identity: true),
                        CodigoTipo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TipoVeiculoID);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        ModeloID = c.Int(nullable: false, identity: true),
                        CodigoModelo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        Marca_MarcaID = c.Int(),
                    })
                .PrimaryKey(t => t.ModeloID)
                .ForeignKey("dbo.Marcas", t => t.Marca_MarcaID)
                .Index(t => t.Marca_MarcaID);
            
            CreateTable(
                "dbo.PeriodoLocacaos",
                c => new
                    {
                        PeriodoID = c.Int(nullable: false, identity: true),
                        CodigoPeriodo = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeVagas = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        TipoVeiculo_TipoVeiculoID = c.Int(),
                    })
                .PrimaryKey(t => t.PeriodoID)
                .ForeignKey("dbo.TipoVeiculoes", t => t.TipoVeiculo_TipoVeiculoID)
                .Index(t => t.TipoVeiculo_TipoVeiculoID);
            
            CreateTable(
                "dbo.TermoDeLocacaos",
                c => new
                    {
                        TermoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TermoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "TermoDeLocacao_TermoID", "dbo.TermoDeLocacaos");
            DropForeignKey("dbo.Locacaos", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CodigoPeriodo_PeriodoID", "dbo.PeriodoLocacaos");
            DropForeignKey("dbo.PeriodoLocacaos", "TipoVeiculo_TipoVeiculoID", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CodigoModelo_ModeloID", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "CodigoMarca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "CodigoTipo_TipoVeiculoID", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CodigoCor_CorId", "dbo.CordoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CodigoColaborador_ColaboradorId", "dbo.Colaboradors");
            DropIndex("dbo.PeriodoLocacaos", new[] { "TipoVeiculo_TipoVeiculoID" });
            DropIndex("dbo.Modeloes", new[] { "Marca_MarcaID" });
            DropIndex("dbo.Marcas", new[] { "CodigoTipo_TipoVeiculoID" });
            DropIndex("dbo.Locacaos", new[] { "TermoDeLocacao_TermoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoTipo_TipoVeiculoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoPeriodo_PeriodoID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoModelo_ModeloID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoMarca_MarcaID" });
            DropIndex("dbo.Locacaos", new[] { "CodigoCor_CorId" });
            DropIndex("dbo.Locacaos", new[] { "CodigoColaborador_ColaboradorId" });
            DropTable("dbo.TermoDeLocacaos");
            DropTable("dbo.PeriodoLocacaos");
            DropTable("dbo.Modeloes");
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Locacaos");
            DropTable("dbo.CordoVeiculoes");
            DropTable("dbo.Colaboradors");
            DropTable("dbo.Administradors");
        }
    }
}
