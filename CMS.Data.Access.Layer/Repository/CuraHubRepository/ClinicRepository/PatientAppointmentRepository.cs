﻿using CMS.Data.Access.Layer.Data;
using CMS.Data.Access.Layer.Repository.IRepository.ICuraHubRepository.IClinicRepository;
using CMS.Models.CuraHub.ClinicSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Access.Layer.Repository.CuraHubRepository.ClinicRepository
{
    public class PatientAppointmentRepository : Repository<PatientAppointment>, IPatientAppointmentRepository
    {
        public PatientAppointmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
