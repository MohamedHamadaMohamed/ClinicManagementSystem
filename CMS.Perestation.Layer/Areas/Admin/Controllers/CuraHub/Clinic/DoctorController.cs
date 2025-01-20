using CMS.Data.Access.Layer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Clinic
{
    [Area(nameof(Admin))]
    //[Authorize(Roles = ($"{Role.AdminRole}"))]
    [Route("Admin/CuraHub/Clinic/ClinicReceptionist")]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [Route("Index")]
        public IActionResult Index(string? query = null, int PageNumber = 1)
        {

            var doctors = _unitOfWork.DoctorRepository.Retrive(includeProps: [e => e.Schedules , e =>e.qualifications , e => e.ClinicReceptionists , e =>e.RequestClinicReceptionists , e=>e.QuestionAndAnswers]);
            if (query != null)
            {
                query = query.Trim();

                doctors = doctors.Where(e => e.FirstName.Contains(query) || e.LastName.Contains(query) || e.PersonalNationalIDNumber.Contains(query));
            }
            if (PageNumber < 1) PageNumber = 1;
            doctors = doctors.Skip((PageNumber - 1) * 5).Take(5);

            return View(doctors.ToList());
        }
    }
}
