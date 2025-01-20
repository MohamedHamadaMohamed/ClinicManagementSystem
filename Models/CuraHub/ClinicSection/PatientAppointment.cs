using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.ClinicSection
{
    public class PatientAppointment
    {

        public int PatientId { get; set; }

        public Patient Patient { get; set; } = null!;
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; } = null!;

    }
}
