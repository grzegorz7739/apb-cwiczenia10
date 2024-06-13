using apbd_cwiczenia10.Data;
using apbd_cwiczenia10.Models;
using apbd_cwiczenia10.Requests;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cwiczenia10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly ApplicationContext _context;
            
        public PrescriptionController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddPrescription(AddPrescriptionRequest request)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.FirstName == request.Patient.PatientFirstName &&
                                                                     p.LastName == request.Patient.PatientLastName &&
                                                                     p.Id == request.Patient.PatientId &&
                                                                     p.Birthday == request.Patient.PatientBirthday);
            if (patient == null)
            {
                patient = new Patient { Id = request.Patient.PatientId , 
                    FirstName = request.Patient.PatientFirstName,
                    LastName = request.Patient.PatientLastName,
                    Birthday = request.Patient.PatientBirthday
                };
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == request.DoctorId);
            if (doctor == null)
            {
                return NotFound("Lekarz o podanym Id nie istnieje.");
            }
            
            var medicamentIds = request.Medicaments.Select(m => m.MedicamentId).ToList();
            var existingMedicaments = _context.Medicaments.Where(m => medicamentIds.Contains(m.Id)).ToList();
            if (existingMedicaments.Count != request.Medicaments.Count)
            {
                return NotFound("Nie wszystkie leki na recepcie istnieją.");
            }
            
            if (request.Medicaments.Count > 10)
            {
                return BadRequest("Recepta może obejmować maksymalnie 10 leków.");
            }
            
            if (request.DueDate < request.Date)
            {
                return BadRequest("DueDate musi być większe lub równe Date.");
            }
            
            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                DoctorId = request.DoctorId,
                PatientId = request.Patient.PatientId,
                PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
                {
                    MedicamentId = m.MedicamentId,
                    Dose = m.Dose,
                    Details = m.Details
                }).ToList()
            };

            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();

            return Ok("Recepta została pomyślnie dodana.");
        }
}