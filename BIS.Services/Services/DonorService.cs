using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BIS.DAL.EF;
using BIS.Model.DataModels;
using BIS.Services.Interfaces;
using BIS.Services.Services;
using BIS.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace BIS.Services.Services
{
    public class DonorService : BaseService, IDonorService
    {
        public DonorService (ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) {}

        public DonorVm AddOrUpdateDonor (AddOrUpdateDonorVm addOrUpdateVm)
        {
            try {
                if (addOrUpdateVm == null)
                    throw new ArgumentNullException ($"View model parameter is null");
                var donorEntity = Mapper.Map<Donor> (addOrUpdateVm);
                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                    DbContext.Donors.Add (donorEntity);
                else
                    DbContext.Donors.Update (donorEntity);
                DbContext.SaveChanges ();
                var donorVm = Mapper.Map<DonorVm> (donorEntity);
                return donorVm;
            } catch (Exception ex) {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public DonorVm GetDonor(Expression<Func<Donor, bool>> filterExpression)
        {
            try {
                if (filterExpression == null ) throw new ArgumentNullException ($"filterPredicate is null");
                var donorEntity = DbContext.Donors.FirstOrDefault (filterExpression);
                var donorVm = Mapper.Map<DonorVm> (donorEntity);
                return donorVm;
            } catch (Exception ex) {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<DonorVm> GetDonors(Expression<Func<Donor, bool>> filterExpression = null)
        {
            try {
            var donorEntities = DbContext.Donors.AsQueryable ();
                if (filterExpression != null)
                    donorEntities = donorEntities.Where (filterExpression);
                var donorVms = Mapper.Map<IEnumerable<DonorVm>> (donorEntities);
                return donorVms;
            } catch (Exception ex) {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }
    }
}