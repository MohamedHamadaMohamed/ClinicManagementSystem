using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.ForCustomerSection.DoctorVMSection;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Utitlities.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Clinic
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Clinic/Doctor")]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public DoctorController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index(string? query = null, int PageNumber = 1, int? SpecializationId = null, string? Title = null, string? State = null, string? City = null, int? Rate = null, int? ConsultationFees = null ,string? Gender=null)
        {
            var doctors = _unitOfWork.DoctorRepository.Retrive(includeProps: [e => e.Specialization]);

            if (query != null)
            {
                query = query.Trim();

                doctors = doctors.Where(e => e.FirstName.Contains(query) || e.LastName.Contains(query) || e.PersonalNationalIDNumber.Contains(query));
            }
            if (Gender != null)
            {
                Gender = Gender.Trim();

                doctors = doctors.Where(e => e.Gender.Contains(Gender));
            }

            if (SpecializationId != null)
            {

                doctors = doctors.Where(e => e.SpecializationId == SpecializationId);
            }
            if (Title != null)
            {
                Title = Title.Trim();

                doctors = doctors.Where(e => e.Title.Contains(Title));
            }
            if (State != null)
            {
                State = State.Trim();

                doctors = doctors.Where(e => e.State.Contains(State));
            }
            if (City != null)
            {
                City = City.Trim();

                doctors = doctors.Where(e => e.City.Contains(City));
            }

            if (Rate != null)
            {

                doctors = doctors.Where(e => ((e.Rate <= Rate) && (e.Rate >= Rate)));
            }
            if (ConsultationFees != null)
            {
                if (ConsultationFees != 401)
                {
                    doctors = doctors.Where(e => ((e.ConsultationFees <= ConsultationFees) && (e.ConsultationFees >= ConsultationFees)));

                }
                else
                {
                    doctors = doctors.Where(e => ((e.ConsultationFees >= ConsultationFees)));

                }
            }
            Cust_DoctorsVM cust_DoctorsVM = new Cust_DoctorsVM();

            cust_DoctorsVM.TotalDoctorCount = doctors.Count();
            if (PageNumber < 1) PageNumber = 1;
            cust_DoctorsVM.CurrentPage = PageNumber;
            
            doctors = doctors.Skip((PageNumber - 1) * 5).Take(5);

            cust_DoctorsVM.Doctors = doctors.ToList();
            cust_DoctorsVM.Specializations = this._unitOfWork.SpecializationRepository.Retrive().ToList();
            cust_DoctorsVM.Schedules = this._unitOfWork.ScheduleRepository.Retrive().ToList();


            return View(cust_DoctorsVM);
        }
    }
}
