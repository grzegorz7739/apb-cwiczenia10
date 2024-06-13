using apbd_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cwiczenia10.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("Prescriptions");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Date);
        
        builder.HasOne(e => e.Patient)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.PatientId);
        
        builder.HasOne(p => p.Doctor)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.DoctorId);
        
        builder.Property(e => e.DoctorId);
        builder.Property(e => e.DueDate);
        builder.Property(e => e.PatientId);
        
        builder.HasMany(e => e.PrescriptionMedicaments)
            .WithOne(e => e.Prescription)
            .HasForeignKey(p => p.PrescriptionId);
    }
}