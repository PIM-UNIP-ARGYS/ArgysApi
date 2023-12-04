using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArgysApi.Models.Admin;
using ArgysApi.Models.Empresas;
using ArgysApi.Models.Usuarios;
using ArgysApi.Models.Feriados;
using ArgysApi.Models.Impostos;
using ArgysApi.Models.Pessoas;
using ArgysApi.Models.Vinculos;

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

        public DbSet<ArgysApi.Models.Impostos.SalarioFamilia> SalarioFamilia { get; set; } = default!;

        public DbSet<ArgysApi.Models.Impostos.PlanoSaude> PlanoSaude { get; set; } = default!;

        public DbSet<ArgysApi.Models.Impostos.Irrf> Irrf { get; set; } = default!;

        public DbSet<ArgysApi.Models.Impostos.Inss> Inss { get; set; } = default!;

        public DbSet<ArgysApi.Models.Impostos.Imposto> Imposto { get; set; } = default!;

        public DbSet<ArgysApi.Models.Pessoas.Pessoa> Pessoa { get; set; } = default!;

        public DbSet<ArgysApi.Models.Pessoas.PessoaEmail> PessoaEmail { get; set; } = default!;

        public DbSet<ArgysApi.Models.Pessoas.PessoaEndereco> PessoaEndereco { get; set; } = default!;

        public DbSet<ArgysApi.Models.Pessoas.PessoaNaturalidade> PessoaNaturalidade { get; set; } = default!;

        public DbSet<ArgysApi.Models.Pessoas.PessoaTelefone> PessoaTelefone { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Agencia> Agencia { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.AgenciaEmail> AgenciaEmail { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.AgenciaTelefone> AgenciaTelefone { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Banco> Banco { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Cargo> Cargo { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Cbo> Cbo { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Ferias> Ferias { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.FeriasHistorico> FeriasHistorico { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Plr> Plr { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.PlrSeg> PlrSeg { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.QuadroHorario> QuadroHorario { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Turno> Turno { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.Vinculo> Vinculo { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.VinculoCargo> VinculoCargo { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.VinculoHorario> VinculoHorario { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.VinculoPlanoSaude> VinculoPlanoSaude { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.VinculoSalario> VinculoSalario { get; set; } = default!;

        public DbSet<ArgysApi.Models.Vinculos.VinculoTransporte> VinculoTransporte { get; set; } = default!;

        public DbSet<ArgysApi.Models.FolhaPagamento.Fp> Fp { get; set; } = default!;
    }
}
