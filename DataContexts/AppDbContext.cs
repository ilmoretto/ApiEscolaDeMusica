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
        public DbSet<Ministra> Ministra { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().ToTable("aluno");
            modelBuilder.Entity<Professor>().ToTable("professor");
            modelBuilder.Entity<Curso>().ToTable("curso");
            modelBuilder.Entity<Sala>().ToTable("sala");
            modelBuilder.Entity<Turma>().ToTable("turma");
            modelBuilder.Entity<ResponsavelAluno>().ToTable("responsavel_aluno");
            modelBuilder.Entity<DisponibilidadeProfessor>().ToTable("disponibilidade_professor");
            modelBuilder.Entity<Ministra>().ToTable("ministra");
            modelBuilder.Entity<Agenda>().ToTable("agenda");
            modelBuilder.Entity<Contrato>().ToTable("contrato");

            modelBuilder.Entity<Aluno>(e =>
                e.Property(x => x.StatusAluno).HasConversion<string>().HasMaxLength(30));

            modelBuilder.Entity<Professor>(e =>
                e.Property(x => x.StatusProf).HasConversion<string>().HasMaxLength(30));

            modelBuilder.Entity<Curso>(e =>
                e.Property(x => x.Nivel).HasConversion<string>().HasMaxLength(30));

            modelBuilder.Entity<Turma>(e =>
            {
                e.Property(x => x.StatusTurma).HasConversion<string>().HasMaxLength(30);
                e.Property(x => x.DiaSemana).HasConversion<string>().HasMaxLength(15);
            });

            modelBuilder.Entity<ResponsavelAluno>(e =>
                e.Property(x => x.Parentesco).HasConversion<string>().HasMaxLength(30));

            modelBuilder.Entity<DisponibilidadeProfessor>(e =>
            {
                e.Property(x => x.DiaSemana).HasConversion<string>().HasMaxLength(15);
                e.Property(x => x.StatusDisp).HasConversion<string>().HasMaxLength(30);
            });

            modelBuilder.Entity<Agenda>(e =>
                e.Property(x => x.StatusAgenda).HasConversion<string>().HasMaxLength(30));

            modelBuilder.Entity<Contrato>(e =>
                e.Property(x => x.StatusContrato).HasConversion<string>().HasMaxLength(30));
        }
    }
}
