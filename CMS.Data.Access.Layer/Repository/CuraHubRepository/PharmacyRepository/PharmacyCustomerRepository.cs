﻿using CMS.Data.Access.Layer.Data;
using CMS.Data.Access.Layer.Repository.IRepository.ICuraHubRepository.IPharmacyRepository;
using CMS.Models.CuraHub.PharmacySection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Access.Layer.Repository.CuraHubRepository.PharmacyRepository
{
    public class PharmacyCustomerRepository : Repository<PharmacyCustomer>, IPharmacyCustomerRepository
    {
        public PharmacyCustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
