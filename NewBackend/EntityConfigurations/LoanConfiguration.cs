using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;
using System;

namespace NewBackend
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans", "db");
            builder.HasKey(a => a.IdLoan);
            builder.Property(a => a.IdLoan)
                    .HasColumnType("int")
                    .IsRequired();
                    // .ValueGeneratedOnAdd();
            builder.Property(a => a.DateStart)
                    .HasColumnType("datetime")
                    .IsRequired();
            builder.Property(a => a.DateReturn)
                    .HasColumnType("datetime");



            // builder.HasData(new Loan(1, DateTime.Parse("2020-04-03") , DateTime.Parse("2020-04-07 19:17:25.8909926"), 1,1));
            // builder.HasData(new Loan(2, DateTime.Parse("2020-03-05") , null, 2,3));
        }
    }
}