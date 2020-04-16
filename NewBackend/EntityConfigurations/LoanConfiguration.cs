using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

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
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(a => a.DateStart)
                    .HasColumnType("datetime")
                    .IsRequired();        
            builder.Property(a => a.DateReturn)
                    .HasColumnType("datetime");
        }
    }
}