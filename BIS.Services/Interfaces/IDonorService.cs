using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BIS.Model.DataModels;
using BIS.ViewModels.VM;

namespace BIS.Services.Interfaces
{
    public interface IDonorService
    {
        DonorVm GetDonor (Expression<Func<Donor, bool>> filterExpression);
        IEnumerable<DonorVm> GetDonors (Expression<Func<Donor, bool>> filterExpression = null);
        DonorVm AddOrUpdateDonor (AddOrUpdateDonorVm addOrUpdateVm);
    }
}