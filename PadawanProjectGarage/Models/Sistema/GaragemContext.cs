using PadawanProjectGarage.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PadawanProjectGarage.Models.Sistema
{
    public class GaragemContext : DbContext
    {
        public DbSet<Administrador> Administradors { get; set; }
        public DbSet<Colaborador> Colaboradors { get; set; }
        public DbSet<Locacao> Locacaos { get; set; }
        public DbSet<PeriodoLocacao> PeriodoLocacaos { get; set; }
        public DbSet<TermoDeLocacao> TermoDeLocacaos { get; set; }
        
        public DbSet<CordoVeiculo> CordoVeiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }
    }
}