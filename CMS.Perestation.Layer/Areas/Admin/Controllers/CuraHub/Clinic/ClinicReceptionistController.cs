using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Utitlities.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Clinic
{
    [Area(nameof(Admin))]
    //[Authorize(Roles = ($"{Role.AdminRole}"))]
    [Route("Admin/CuraHub/Clinic/ClinicReceptionist")]
    public class ClinicReceptionistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClinicReceptionistController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [Route("Index")]
        public IActionResult Index(string? query = null, int PageNumber = 1)
        {
            var clinicReceptionists = _unitOfWork.ClinicReceptionistRepository.Retrive(includeProps: [e=>e.Doctor]);
            if(query != null)
            {
                query = query.Trim();

                clinicReceptionists = clinicReceptionists.Where(e => e.FirstName.Contains(query) || e.LastName.Contains(query) || e.PersonalNationalIDNumber.Contains(query));
            }
            var TotalActorCount = (clinicReceptionists.Count() + 4) / 5;
            if (PageNumber < 1) PageNumber = 1;
            clinicReceptionists = clinicReceptionists.Skip((PageNumber - 1) * 5).Take(5);

            return View(clinicReceptionists.ToList());
        }
    }
}
