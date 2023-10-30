using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Models.Admin;
using ArgysApi.Models.Empresas;
using ArgysApi.Models.Usuarios;
using ArgysApi.Models.Feriados;

namespace ArgysApi.Data
{
    public class ArgysApiContext : DbContext
    {
        public ArgysApiContext (DbContextOptions<ArgysApiContext> options)
            : base(options)
        {
        }

        public DbSet<Administradora> Administradora { get; set; } = default!;

        public DbSet<EnderecoAdministradora> EnderecoAdministradora { get; set; } = default!;

        public DbSet<ArgysApi.Models.Empresas.Empresa> Empresa { get; set; } = default!;

        public DbSet<ArgysApi.Models.Empresas.EnderecoEmpresa> EnderecoEmpresa { get; set; } = default!;

        public DbSet<ArgysApi.Models.Empresas.GrupoEmpresa> GrupoEmpresa { get; set; } = default!;

        public DbSet<ArgysApi.Models.Usuarios.Usuario> Usuario { get; set; } = default!;

        public DbSet<ArgysApi.Models.Usuarios.UsuarioEmpresa> UsuarioEmpresa { get; set; } = default!;

        public DbSet<ArgysApi.Models.Feriados.Feriado> Feriado { get; set; } = default!;

        public DbSet<ArgysApi.Models.Feriados.FeriadoEmpresa> FeriadoEmpresa { get; set; } = default!;
    }
}
