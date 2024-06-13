namespace apbd_cwiczenia10.Requests;

public class AddPrescriptionRequest
{
    public NewPatientRequest Patient { get; set; }
    public DateTime Date { get; set; } // Data wystawienia recepty
    public DateTime DueDate { get; set; } // Termin realizacji recepty
    public int DoctorId { get; set; } // Id lekarza

    public List<PrescriptionMedicamentRequest> Medicaments { get; set; } // Lista leków na recepcie
}
