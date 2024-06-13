namespace apbd_cwiczenia10.Requests;

public class AddPrescriptionRequest
{
    public NewPatientRequest Patient { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int DoctorId { get; set; }

    public List<PrescriptionMedicamentRequest> Medicaments { get; set; }
}
