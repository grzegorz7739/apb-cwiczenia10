namespace apbd_cwiczenia10.Requests;

public class PrescriptionMedicamentRequest
{
    public int MedicamentId { get; set; } // Id leku
    public int Dose { get; set; } // Dawka leku
    public string Details { get; set; } // Dodatkowe informacje
}