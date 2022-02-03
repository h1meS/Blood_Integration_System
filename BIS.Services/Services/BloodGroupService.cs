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
    public class BloodGroupService : BaseService, IBloodGroupService
    {
        private readonly UserManager<User> _userManager;
        public BloodGroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public BloodGroupVm GetBloodGroup(Expression<Func<BloodGroup, bool>> filterPredicate)
        {
            if (filterPredicate == null ) {
                throw new ArgumentNullException ($"Predicate is null");
            }
            var bloodgroupEntity =DbContext.BloodGroups
                .FirstOrDefault (filterPredicate);
            var bloodgroupVm = Mapper.Map<BloodGroupVm> (bloodgroupEntity);
            return bloodgroupVm;
        }

        public IEnumerable<BloodGroupVm> GetBloodGroups(Expression<Func<BloodGroup, bool>> filterPredicate = null)
        {
            var bloodgroupEntities = DbContext.BloodGroups.AsQueryable ();
            if (filterPredicate != null){
                bloodgroupEntities = bloodgroupEntities.Where (filterPredicate);
            }
            var bloodgroupVms = Mapper.Map<IEnumerable<BloodGroupVm>> (bloodgroupEntities.ToList());
            return bloodgroupVms;
        }

        public BloodGroupVm AddOrUpdateBloodGroup (AddOrUpdateBloodGroupVm addOrUpdateBloodGroupVm) {
            if (addOrUpdateBloodGroupVm == null) {
                throw new ArgumentNullException ($"Vm of type is null");
            }
            var bloodgroupEntity = Mapper.Map<BloodGroup> (addOrUpdateBloodGroupVm);
            if (addOrUpdateBloodGroupVm.Id == null || addOrUpdateBloodGroupVm.Id == 0) {
                DbContext.BloodGroups.Add (bloodgroupEntity);
            } else {
                DbContext.BloodGroups.Update (bloodgroupEntity);
            }
            DbContext.SaveChanges ();
            var bloodgroupVm = Mapper.Map<BloodGroupVm> (bloodgroupEntity);
            return bloodgroupVm;
        }

        public BloodGroupVm AttachDonorToBloodGroup(AttachDetachDonorBloodVm attachDonorBlood)
        {
            if (attachDonorBlood == null) {
                throw new ArgumentNullException ($"Vm of type is null");
            }
            var donorBlood = DbContext.DonorBloods
                .FirstOrDefault (sg => sg.BloodGroupId == attachDonorBlood.BloodGroupId && sg.DonorId == attachDonorBlood.DonorId);
            if (donorBlood != null) {
                throw new ArgumentNullException ($"There is such attachment already defined.");
            }
            donorBlood = new DonorBlood {
                BloodGroupId = attachDonorBlood.BloodGroupId,
                DonorId = attachDonorBlood.DonorId
            };
            DbContext.DonorBloods.Add (donorBlood);
            DbContext.SaveChanges ();
            var bloudgroup = DbContext.BloodGroups.FirstOrDefault (x => x.Id == attachDonorBlood.BloodGroupId);
            var bloudgroupVm = Mapper.Map<BloodGroupVm> (bloudgroup);
            return bloudgroupVm;
        }

        public BloodGroupVm DetachDonorFromBloodGroup(AttachDetachDonorBloodVm detachDonorVm)
        {
            if (detachDonorVm == null) {
                throw new ArgumentNullException ($"Vm of type is null");
            }
            var donorBlood = DbContext.DonorBloods
                .FirstOrDefault (sg => sg.BloodGroupId == detachDonorVm.BloodGroupId && sg.DonorId == detachDonorVm.DonorId);
            if (donorBlood == null) {
                throw new ArgumentNullException ($"The is no such attachment between blood group and donor");
            }
            DbContext.DonorBloods.Remove (donorBlood);
            DbContext.Remove (donorBlood);
            DbContext.SaveChanges ();
            var bloudgroup = DbContext.BloodGroups.FirstOrDefault (x => x.Id == detachDonorVm.BloodGroupId);
            var bloudgroupVm = Mapper.Map<BloodGroupVm> (bloudgroup);
            return bloudgroupVm;
        }
    }
}