using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.ForCustomerSection.DoctorVMSection
{
    public class Cust_DoctorsVM
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Specialization> Specializations { get; set; } = new List<Specialization>();

        public List<Schedule> Schedules { get; set; } = new List<Schedule> ();
        public int TotalDoctorCount {  get; set; }
        public int CurrentPage { get; set; }

    }
}
