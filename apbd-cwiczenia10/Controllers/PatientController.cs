using apbd_cwiczenia10.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd_cwiczenia10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly ApplicationContext _context;

    public PatientController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("{patientId}")]
    public IActionResult GetPatientDetails(int patientId)
    {
        try
        {
            var patient = _context.Patients
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Doctor)
                .FirstOrDefault(p => p.Id == patientId);
            

            if (patient == null)
            {
                return NotFound("Pacjent o podanym Id nie został znaleziony.");
            }
            
            patient.Prescriptions = patient.Prescriptions.OrderByDescending(pr => pr.DueDate).ToList();
            
            return Ok(patient);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Wystąpił nieoczekiwany błąd: {ex.Message}");
        }
    }
}