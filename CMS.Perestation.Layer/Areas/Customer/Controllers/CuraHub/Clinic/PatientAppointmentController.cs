using CMS.Data.Access.Layer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Clinic
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Clinic/PatientAppointment")]
    public class PatientAppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // Customer/CuraHub/Clinic/PatientAppointment/Index
        public PatientAppointmentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [Route("Index")]
        public IActionResult Index(DateOnly date, int DoctorId)
        {
            //var patients = this._unitOfWork.PatientRepository.Retrive().Include(e => e.PatientAppointments);
            var appointments = this._unitOfWork.PatientAppointmentRepository.Retrive(filter: e => e.date == date && e.Schedule.DoctorId == DoctorId,
                includeProps: [e => e.Patient]
                ).Include(e => e.Schedule).ThenInclude(e => e.Doctor).ToList();


            return View(appointments);
        }

    }
}
