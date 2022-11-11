using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleEmailApplication.Models
{
    public partial class EmailOtpAuthContext : DbContext
    {
        public EmailOtpAuthContext()
        {
        }

        public EmailOtpAuthContext(DbContextOptions<EmailOtpAuthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailOtp> EmailOtps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailOtp>(entity =>
            {
                entity.ToTable("EmailOtp");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Otp)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
