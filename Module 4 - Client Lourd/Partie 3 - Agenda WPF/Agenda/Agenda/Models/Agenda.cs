namespace Agenda.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Agenda : DbContext
    {
        public Agenda()
            : base("name=Agenda")
        {
        }

        public virtual DbSet<appointments> appointments { get; set; }
        public virtual DbSet<brokers> brokers { get; set; }
        public virtual DbSet<customers> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<appointments>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.brokers)
                .HasForeignKey(e => e.id_brokers);

            modelBuilder.Entity<customers>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.customers)
                .HasForeignKey(e => e.id_customers);
        }
    }
}
