namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<evaluaciones> evaluaciones { get; set; }
        public virtual DbSet<proyectos> proyectos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categorias>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.audiencia)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.escala)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.formula)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.evaluaciones)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.categorias_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<evaluaciones>()
                .Property(e => e.a)
                .IsUnicode(false);

            modelBuilder.Entity<evaluaciones>()
                .Property(e => e.b)
                .IsUnicode(false);

            modelBuilder.Entity<evaluaciones>()
                .Property(e => e.c)
                .IsUnicode(false);

            modelBuilder.Entity<evaluaciones>()
                .Property(e => e.resultado)
                .IsUnicode(false);

            modelBuilder.Entity<evaluaciones>()
                .Property(e => e.fecha)
                .HasPrecision(0);

            modelBuilder.Entity<proyectos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<proyectos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<proyectos>()
                .Property(e => e.evaluador)
                .IsUnicode(false);

            modelBuilder.Entity<proyectos>()
                .HasMany(e => e.evaluaciones)
                .WithRequired(e => e.proyectos)
                .HasForeignKey(e => e.proyectos_id)
                .WillCascadeOnDelete(false);
        }
    }
}
