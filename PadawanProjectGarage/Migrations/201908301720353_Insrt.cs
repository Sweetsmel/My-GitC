namespace PadawanProjectGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insrt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        AdministradorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
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
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Idoso = c.Boolean(nullable: false),
                        PCD = c.Boolean(nullable: false),
                        PeriodoNoturo = c.Boolean(nullable: false),
                        OfereceCarona = c.Boolean(nullable: false),
                        ResideFora = c.Boolean(nullable: false),
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
                        Descricao = c.String(nullable: false),
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
                        AceitaTermo = c.Boolean(nullable: false),
                        Veiculofk = c.Int(),
                        MarcaFK = c.Int(),
                        ModeloFK = c.Int(),
                        CordoVeiculoFK = c.Int(),
                        PeriodoLocacaoFK = c.Int(),
                        ColaboradorFK = c.Int(),
                        TermoDeLocacaoFK = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocacaoID)
                .ForeignKey("dbo.Colaboradors", t => t.ColaboradorFK)
                .ForeignKey("dbo.CordoVeiculoes", t => t.CordoVeiculoFK)
                .ForeignKey("dbo.Marcas", t => t.MarcaFK)
                .ForeignKey("dbo.Modeloes", t => t.ModeloFK)
                .ForeignKey("dbo.PeriodoLocacaos", t => t.PeriodoLocacaoFK)
                .ForeignKey("dbo.TermoDeLocacaos", t => t.TermoDeLocacaoFK)
                .ForeignKey("dbo.TipoVeiculoes", t => t.Veiculofk)
                .Index(t => t.Veiculofk)
                .Index(t => t.MarcaFK)
                .Index(t => t.ModeloFK)
                .Index(t => t.CordoVeiculoFK)
                .Index(t => t.PeriodoLocacaoFK)
                .Index(t => t.ColaboradorFK)
                .Index(t => t.TermoDeLocacaoFK);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        CodigoMarca = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        VeiculoFK = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MarcaID)
                .ForeignKey("dbo.TipoVeiculoes", t => t.VeiculoFK)
                .Index(t => t.VeiculoFK);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        TipoVeiculoID = c.Int(nullable: false, identity: true),
                        CodigoTipo = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
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
                        Descricao = c.String(nullable: false),
                        MarcaFK = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ModeloID)
                .ForeignKey("dbo.Marcas", t => t.MarcaFK)
                .Index(t => t.MarcaFK);
            
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
                        Veiculofk = c.Int(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodoID)
                .ForeignKey("dbo.TipoVeiculoes", t => t.Veiculofk)
                .Index(t => t.Veiculofk);
            
            CreateTable(
                "dbo.TermoDeLocacaos",
                c => new
                    {
                        TermoID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Vigente = c.Boolean(nullable: false),
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
            DropForeignKey("dbo.Locacaos", "Veiculofk", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "TermoDeLocacaoFK", "dbo.TermoDeLocacaos");
            DropForeignKey("dbo.Locacaos", "PeriodoLocacaoFK", "dbo.PeriodoLocacaos");
            DropForeignKey("dbo.PeriodoLocacaos", "Veiculofk", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "ModeloFK", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "MarcaFK", "dbo.Marcas");
            DropForeignKey("dbo.Locacaos", "MarcaFK", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "VeiculoFK", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "CordoVeiculoFK", "dbo.CordoVeiculoes");
            DropForeignKey("dbo.Locacaos", "ColaboradorFK", "dbo.Colaboradors");
            DropIndex("dbo.PeriodoLocacaos", new[] { "Veiculofk" });
            DropIndex("dbo.Modeloes", new[] { "MarcaFK" });
            DropIndex("dbo.Marcas", new[] { "VeiculoFK" });
            DropIndex("dbo.Locacaos", new[] { "TermoDeLocacaoFK" });
            DropIndex("dbo.Locacaos", new[] { "ColaboradorFK" });
            DropIndex("dbo.Locacaos", new[] { "PeriodoLocacaoFK" });
            DropIndex("dbo.Locacaos", new[] { "CordoVeiculoFK" });
            DropIndex("dbo.Locacaos", new[] { "ModeloFK" });
            DropIndex("dbo.Locacaos", new[] { "MarcaFK" });
            DropIndex("dbo.Locacaos", new[] { "Veiculofk" });
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
