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
    public class DonorController : BaseController
    {
        private readonly IDonorService _donorService;
        private readonly UserManager<User> _userManager;
        public DonorController(IDonorService donorService, UserManager<User> userManager, IStringLocalizer localizer, ILogger logger, IMapper mapper) : base(logger, mapper, localizer)
        {
            _donorService = donorService;
            _userManager = userManager;
        }

        public IActionResult Index() 
        { 
            var user = _userManager.GetUserAsync(User).Result; 
            if (_userManager.IsInRoleAsync(user, "Admin").Result) 
                return View(_donorService.GetDonors()); 
            else 
                return View("Error"); 
        }

        [HttpGet] 
        [Authorize(Roles = "Admin")] 
        public IActionResult AddOrEditDonor(int? id = null) 
        { 
            if (id.HasValue) {
                var donorVm = _donorService.GetDonor (d => d.Id == id);
                ViewBag.ActionType = "Edit";
                return View(Mapper.Map<AddOrUpdateDonorVm> (donorVm));
            }
            ViewBag.ActionType = "Add";
            return View (); 
        } 

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id) 
        { 
            var donorVm = _donorService.GetDonor(d => d.Id == id); 
            return View(donorVm); 
        }

        [HttpPost] 
        [ValidateAntiForgeryToken] 
        [Authorize(Roles = "Admin")] 
        public IActionResult AddOrEditDonor(AddOrUpdateDonorVm addOrUpdateDonorVm) 
        { 
            if (ModelState.IsValid) 
            { 
                _donorService.AddOrUpdateDonor(addOrUpdateDonorVm); 
                return RedirectToAction("Index"); 
            } 
            return View(); 
        }
    }
}
