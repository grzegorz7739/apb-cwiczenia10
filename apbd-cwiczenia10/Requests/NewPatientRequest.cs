namespace apbd_cwiczenia10.Requests;

public class NewPatientRequest
{
    public int PatientId { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public DateTime PatientBirthday { get; set; }
}