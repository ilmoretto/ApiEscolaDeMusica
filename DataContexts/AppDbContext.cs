using AppEscolaDeMusica.Models;
using Microsoft.EntityFrameworkCore;

namespace AppEscolaDeMusica.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<ResponsavelAluno> ResponsaveisAlunos { get; set; }
        public DbSet<DisponibilidadeProfessor> DisponibilidadesProfessores { get; set; }
        public DbSet<Ministra> Ministras { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>()
                .Property(a => a.StatusAluno)
                .HasConversion<string>();

            modelBuilder.Entity<Professor>()
                .Property(p => p.StatusProf)
                .HasConversion<string>();

            modelBuilder.Entity<Curso>()
                .Property(c => c.Nivel)
                .HasConversion<string>();

            modelBuilder.Entity<Turma>()
                .Property(t => t.StatusTurma)
                .HasConversion<string>();

            modelBuilder.Entity<Turma>()
                .Property(t => t.DiaSemana)
                .HasConversion<string>();

            modelBuilder.Entity<ResponsavelAluno>()
                .Property(r => r.Parentesco)
                .HasConversion<string>();

            modelBuilder.Entity<DisponibilidadeProfessor>()
                .Property(d => d.DiaSemana)
                .HasConversion<string>();

            modelBuilder.Entity<DisponibilidadeProfessor>()
                .Property(d => d.StatusDisp)
                .HasConversion<string>();

            modelBuilder.Entity<Agenda>()
                .Property(a => a.StatusAgenda)
                .HasConversion<string>();

            modelBuilder.Entity<Contrato>()
                .Property(c => c.StatusContrato)
                .HasConversion<string>();

        }
    }
}