using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.ClinicSection;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.PatientVM;
using CMS.Models.CuraHub.IdentitySection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Clinic
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Clinic/Patient")]
    public class PatientController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public PatientController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        [HttpGet]
        [Route("Upsert")]
        public IActionResult Upsert(PatientUpsartVM patientUpsartVM ,int ScheduleId , DateOnly date)
        {
                      

            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if (user != null)
            {
                patientUpsartVM.ApplicationUserId = user.Id;
                patientUpsartVM.FirstName = patientUpsartVM.FirstName??user.FirstName;
                patientUpsartVM.LastName = patientUpsartVM.LastName??user.LastName;
                patientUpsartVM.Email = user.Email??"@CuraHub.com";
                patientUpsartVM.ProfilePicture = patientUpsartVM.ProfilePicture??"PatientDefault.avif";
                var schedule = _unitOfWork.ScheduleRepository.RetriveItem(e => e.Id == ScheduleId);
               if(schedule !=null)
                {
                    patientUpsartVM.DoctorId = schedule.DoctorId;

                }
                patientUpsartVM.patientAppointment.ScheduleId = ScheduleId;
                patientUpsartVM.patientAppointment.date = date;
                return View(patientUpsartVM);

            }
            return RedirectToAction(actionName: "Login", controllerName: "Account", new { area = "Identity" });
        }
        [HttpPost]
        [Route("Upsert")]
        public IActionResult Upsert(PatientUpsartVM patientUpsartVM , PatientAppointment patientAppointment)
        {
            patientUpsartVM.patientAppointment = patientAppointment;
            ModelState.Remove("Schedule");
            ModelState.Remove("Patient");

            ModelState.Remove("patientAppointment.Schedule");
            ModelState.Remove("patientAppointment.Patient");

            patientUpsartVM.City = "Nasr City";





            if (ModelState.IsValid)
            {
                var patient = this._mapper.Map<Patient>(patientUpsartVM);

                this._unitOfWork.PatientRepository.Create(patient);
                this._unitOfWork.Commit();
                var savedPatient = this._unitOfWork.PatientRepository.RetriveItem(e =>e.PersonalNationalIDNumber ==  patient.PersonalNationalIDNumber);
                if (savedPatient != null) 
                {
                    patientAppointment.PatientId = savedPatient.Id;
                    this._unitOfWork.PatientAppointmentRepository.Create(patientAppointment);
                    this._unitOfWork.Commit();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(patientUpsartVM);
        }


    }
}
