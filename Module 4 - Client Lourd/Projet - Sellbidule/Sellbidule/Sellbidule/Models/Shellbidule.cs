namespace Sellbidule.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Shellbidule : DbContext
    {
        public Shellbidule()
            : base("name=Shellbidule")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.reference)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Article)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.id_Category)
                .WillCascadeOnDelete(false);
        }
    }
}
