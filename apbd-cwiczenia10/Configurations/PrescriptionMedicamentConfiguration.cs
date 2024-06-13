using apbd_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cwiczenia10.Configurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.ToTable("PrescriptionMedicaments");
        
        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.PrescriptionId);
        
        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.MedicamentId);
        
        builder.Property(e => e.Details);
        builder.HasKey(e => new {e.PrescriptionId,e.MedicamentId});
        builder.Property(e => e.Dose);
        
    }
}