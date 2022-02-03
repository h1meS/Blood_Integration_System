using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using BIS.Model.DataModels;
using BIS.Services.Interfaces;
using BIS.ViewModels.VM;

namespace BIS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BloodGroupController : BaseController
    {
        private readonly IBloodGroupService _bloodgroupService;
        private readonly IDonorService _donorService;
        private readonly UserManager<User> _userManager;

        public BloodGroupController(IBloodGroupService bloodgroupService, IDonorService donorService, UserManager<User> userManager, IStringLocalizer localizer, ILogger logger, IMapper mapper) : base(logger, mapper, localizer)
        {
            _bloodgroupService = bloodgroupService;
            _donorService = donorService;
            _userManager = userManager;
        }

        public IActionResult Index() 
        { 
            var user = _userManager.GetUserAsync(User).Result; 
            if (_userManager.IsInRoleAsync(user, "Admin").Result) 
                return View(_bloodgroupService.GetBloodGroups()); 
            else 
                return View("Error"); 
        }

        public IActionResult Details (int id) {
            var bloodgroup = _bloodgroupService.GetBloodGroup (g => g.Id == id);
            return View (bloodgroup);
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEditBloodGroup (int? id = null) {
            if (id.HasValue) {
                var bloodgroup = _bloodgroupService.GetBloodGroup (g => g.Id == id.Value);
                ViewBag.ActionType = "Edit";
                var bloudgroupDto = Mapper.Map<AddOrUpdateBloodGroupVm> (bloodgroup);
                return View (bloudgroupDto);
            }
            ViewBag.ActionType = "Add";
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEditBloodGroup (AddOrUpdateBloodGroupVm addOrUpdateBloodGroupVm) {
            if (ModelState.IsValid) {
                _bloodgroupService.AddOrUpdateBloodGroup (addOrUpdateBloodGroupVm);
                return RedirectToAction ("Index");
            }
            return View ();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AttachDonorToBloodGroup (int donorId) {
            return AttachDetachDonorToBloodGroupGetView (donorId);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DetachDonorToBloodGroup (int donorId) {
            return AttachDetachDonorToBloodGroupGetView (donorId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AttachDonorToBloodGroup (AttachDetachDonorBloodVm attachDetachDonorBloodVm) {
            try {
                if (!ModelState.IsValid) {
                    return View("AttachDetachDonorToBloodGroup");
                }
                _bloodgroupService.AttachDonorToBloodGroup (attachDetachDonorBloodVm);
                return RedirectToAction ("Index", "Donor");
            } catch (Exception ex) {
                Logger.LogError (ex, ex.Message);
                ModelState.AddModelError (string.Empty, ex.Message);
                return AttachDetachDonorToBloodGroupGetView ();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DetachDonorToBloodGroup (AttachDetachDonorBloodVm attachDetachDonorBloodVm) {
            try {
                if (!ModelState.IsValid) {
                    return View("AttachDetachDonorToBloodGroup");
                }
                _bloodgroupService.DetachDonorFromBloodGroup (attachDetachDonorBloodVm);
                return RedirectToAction ("Index", "Donor");
            } catch (Exception ex) {
                Logger.LogError (ex, ex.Message);
                ModelState.AddModelError (string.Empty, ex.Message);
                return AttachDetachDonorToBloodGroupGetView ();
            }
        }

        private IActionResult AttachDetachDonorToBloodGroupGetView (int? donorId = null) {
            ViewBag.PostAction = ControllerContext.ActionDescriptor.ActionName;
            if (ControllerContext.ActionDescriptor.ActionName.StartsWith ("Detach")) {
                ViewBag.ActionType = "Detach";
            } else if (ControllerContext.ActionDescriptor.ActionName.StartsWith ("Attach")) {
                ViewBag.ActionType = "Attach";
            } else {
                return View ("Error");
            }
            var donors = _donorService.GetDonors ()
                            .ToList();
            var bloodgroups = _bloodgroupService.GetBloodGroups ();
            var currentDonor = donors.FirstOrDefault (x => x.Id == donorId);
            ViewBag.DonorList = new SelectList (donors.Select (s => new {
                Text = s.FirstName,
                    Value = s.Id,
                    Selected = s.Id == currentDonor?.Id
            }), "Value", "Text");
            ViewBag.BloodGroupList = new SelectList (bloodgroups.Select (s => new {
                Text = s.Type,
                    Value = s.Id
            }), "Value", "Text");
            return View ("AttachDetachDonorToBloodGroup");
        }
    }
}