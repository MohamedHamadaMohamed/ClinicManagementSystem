using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.IdentitySection.IdentitySectionVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Identity.Controllers
{
    [Area(nameof(Identity))]
    [Route("Identity/Account")]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public AccountController( UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._mapper = mapper; 
            
        }


        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterVM registerVM)
        {
            ModelState.Remove("ProfilePicture");
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerVM);
                applicationUser.UserName = registerVM.Email.Split('@')[0];
                applicationUser.ProfilePicture = "Profile.png";


            }
            return View();
        }

    }
}
