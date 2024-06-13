namespace apbd_cwiczenia10.Models;

public class PrescriptionMedicament
{
    public int Dose { get; set; }
    public string Details { get; set; }
    public int MedicamentId { get; set; }
    public int PrescriptionId { get; set; }
    public Medicament Medicament { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;
}