using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BIS.Model.DataModels;
using BIS.ViewModels.VM;

namespace BIS.Services.Interfaces
{
    public interface IBloodGroupService
    {
        BloodGroupVm GetBloodGroup (Expression<Func<BloodGroup, bool>> filterPredicate);
        IEnumerable<BloodGroupVm> GetBloodGroups (Expression<Func<BloodGroup, bool>> filterPredicate = null);
        BloodGroupVm AddOrUpdateBloodGroup (AddOrUpdateBloodGroupVm addOrUpdateBloodGroupVm);
        BloodGroupVm AttachDonorToBloodGroup (AttachDetachDonorBloodVm attachDonorBloodVm);
        BloodGroupVm DetachDonorFromBloodGroup (AttachDetachDonorBloodVm detachDonorVm);
    }
}