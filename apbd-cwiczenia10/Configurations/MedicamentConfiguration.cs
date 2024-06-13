using apbd_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cwiczenia10.Configurations;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.ToTable("Medicaments");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(100);
        builder.Property(e => e.Type).HasMaxLength(100);
        
        builder.HasMany(e => e.PrescriptionMedicaments)
            .WithOne(e => e.Medicament)
            .HasForeignKey(p => p.MedicamentId);
        
        builder.HasData(new List<Medicament>()
        {
            new() { Id = 1, Name = "John", Description = "lorem Ipsum ", Type = "Typ"},
            new() { Id = 2, Name = "Ann", Description = "lorem Ipsum th", Type = "Typ"},
            new() { Id = 3, Name = "Jack", Description = "lorem Ipsum lor", Type = "Typ"}
        });
    }
}