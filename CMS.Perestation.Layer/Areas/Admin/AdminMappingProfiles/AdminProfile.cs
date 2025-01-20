using AutoMapper;
using CMS.Models.CuraHub.IdentitySection.IdentitySectionVM;
using CMS.Models.CuraHub.IdentitySection;

namespace CMS.Perestation.Layer.Areas.Admin.AdminMappingProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserVM>().ReverseMap();
        }
    }
}
