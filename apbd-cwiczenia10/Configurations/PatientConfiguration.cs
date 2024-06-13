using apbd_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cwiczenia10.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName);
        builder.Property(e => e.LastName);
        builder.Property(e => e.Birthday);
        builder.HasMany(d => d.Prescriptions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId);

        builder.HasData(new List<Patient>()
        {
            new() { Id = 1, FirstName = "Juri", LastName = "Gagrin", Birthday = DateTime.Now}
        });
    }
}