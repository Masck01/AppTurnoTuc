using System.Runtime.CompilerServices;
using turnotucapp.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace turnotucapp.Data
{
    public class AppTurnoTucDbContext : DbContext
    {
        public AppTurnoTucDbContext(DbContextOptions<AppTurnoTucDbContext> options) : base(options) { }

        public DbSet<Sucursal> Sucursals { get; set; }
        public DbSet<BocaDeAtencion> Atencions { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<ObraSocial> Obras { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
