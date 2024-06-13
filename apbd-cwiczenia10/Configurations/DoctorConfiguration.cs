using apbd_cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cwiczenia10.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor> 
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.HasMany(d => d.Prescriptions)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.DoctorId);

        builder.HasData(new List<Doctor>()
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe", Email = "John@email.com"},
            new() { Id = 2, FirstName = "Ann", LastName = "Smith", Email = "Ann@email.com"},
            new() { Id = 3, FirstName = "Jack", LastName = "Taylor", Email = "Jack@email.com"}
        });

    }
}