using KargomentoBL.ImplementationsOfManagers;
using KargomentoBL.InterfacesOfManagers;
using KargomentoEL.Constants;
using KargomentoEL.IdentityModels;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace KargomentoUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Route("admin/[Action]/{id?}")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmployeeBranchManager _employeeBranchManager;
        private readonly IBranchManager _branchManager;
        private readonly ICityManager _cityManager;
        private readonly IDistrictManager _districtManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IEmployeeBranchManager employeeBranchManager, IBranchManager branchManager, ICityManager cityManager, IDistrictManager districtManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _employeeBranchManager = employeeBranchManager;
            _branchManager = branchManager;
            _cityManager = cityManager;
            _districtManager = districtManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult AllBranches()
        {
            try
            {
                var data = _branchManager.GetAll().Data;
                foreach (var item in data)
                {
                    item.District.City = _cityManager.GetById(item.District.CityId).Data;
                }
                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata olustu!" + ex.Message);
                return View(new List<BranchVM>());

            }
        }

        public IActionResult NewBranchAdd()
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.Cities = new List<CityVM>();
                return View();
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult NewBranchAdd(BranchVM model)
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Bilgileri düzgün giriniz");
                    return View(model);
                }

                var sameBranch = _branchManager.GetByConditions(x => x.DistrictId == model.DistrictId && x.Name == model.Name).Data;
                if (sameBranch == null)
                {
                    BranchVM branch = new BranchVM()
                    {
                        CreatedDate = DateTime.Now,
                        DistrictId = model.DistrictId,
                        Description = model.Description,
                        Name = model.Name,
                        IsRemoved = false
                    };
                    _branchManager.Add(branch);
                }
                return RedirectToAction("AllBranches", "admin");


            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        public IActionResult AllUsers()
        {
            try
            {
                var allusers = _userManager.Users.ToList();
                List<AppUserRole> model = new List<AppUserRole>();
                foreach (var item in allusers)
                {
                    AppUserRole a = new AppUserRole()
                    {
                        User = item,
                        RoleName = _userManager.GetRolesAsync(item).Result.FirstOrDefault(),
                        BranchName = _employeeBranchManager.GetByConditions(x => x.EmployeeId == item.Id).Data.Branch.Name
                    };
                    model.Add(a);
                }
                return View(model);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [HttpGet]
        public IActionResult AssignBranch(string? userid)
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                ViewBag.Districts = new List<DistrictVM>();
                ViewBag.Branches = new List<BranchVM>();

                //bu userın şubesi var mı?
                var employeeBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == userid).Data;
                if (employeeBranch != null)
                {

                    var district =
                    _districtManager.GetById(employeeBranch.Branch.DistrictId).Data;
                    employeeBranch.Branch.District = district;

                    var city = _cityManager.GetById(district.CityId).Data;
                    employeeBranch.Branch.District.City = city;

                    ViewBag.Districts = _districtManager.GetAll(x => !x.IsRemoved
                    && x.CityId == city.Id).Data;

                    ViewBag.Branches = _branchManager.GetAll(x => x.DistrictId == district.Id).Data;
                    return View(employeeBranch);
                }

                EmployeeBranchVM model = new EmployeeBranchVM();
                model.Branch = new BranchVM();
                model.Branch.District = new DistrictVM();
                model.Branch.District.City = new CityVM();
                return View(model);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [HttpPost]
        public IActionResult AssignBranch(EmployeeBranchVM model)
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                ViewBag.Districts = _districtManager.GetAll(x => !x.IsRemoved && x.CityId == model.Branch.District.City.Id).Data;
                ViewBag.Branches = _branchManager.GetAll(x => x.DistrictId == model.Id).Data;
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("","Bilgileri seçiniz.");
                //    return View(model);
                //}
                //var employeeBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == model.EmployeeId).Data;
                var employeeBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == model.EmployeeId).Data;
                if (employeeBranch == null)
                {
                    ModelState.AddModelError("","error");
                    return View(model);
                }
                employeeBranch.Branch = null;
                employeeBranch.BranchId = model.BranchId;
                employeeBranch.CreatedDate = DateTime.Now;
                employeeBranch.Salary = 20000;
                var result = _employeeBranchManager.Update(employeeBranch);
                return RedirectToAction("AllUsers", "Admin");


            }
            catch (Exception ex)
            {
                return View(model);
            }

            return View();
        }

        [HttpGet]
        //[Route("edit")]
        public IActionResult EditUser(string userid)
        {
            try
            {
                if (string.IsNullOrEmpty(userid))
                {
                    ModelState.AddModelError("", "Id gelmediği için kullanıcı bulunamadı!");
                    return View(new AppUser());
                }
                var user = _userManager.FindByIdAsync(userid).Result;

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı!");
                    return View(new AppUser());
                }

                var allroles = _roleManager.Roles.ToList();
                var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                ViewBag.Roles = allroles;

                AppUserRole model = new AppUserRole()
                {
                    User = user,
                    RoleId = allroles.FirstOrDefault(x => x.Name == userRole).Id
                };

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu!" + ex.Message);
                return View(new AppUser());
            }

        }


        [HttpPost]
        public IActionResult EditUser(AppUserRole model)
        {
            try
            {
                var allroles = _roleManager.Roles.ToList();
                ViewBag.Roles = allroles;
                // Burada işlemler yapılacak
                var member = _userManager.FindByIdAsync(model.User.Id).Result;
                if (member == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı!");
                    return View(model);
                }
                member.Name = model.User.Name;
                member.Surname = model.User.Surname;
                member.Email = model.User.Email;
                member.UserName = model.User.UserName;
                member.TcNo = model.User.TcNo;
                member.PhoneNumber = model.User.PhoneNumber;

                if (_userManager.UpdateAsync(member).Result.Succeeded)
                {
                    TempData["EditUserSuccessMessage"] = "Kullanıcı bilgileri güncellendi!";
                    //role bak
                    var roleName = _userManager.GetRolesAsync(member).Result.FirstOrDefault();
                    AppRole role = _roleManager.FindByNameAsync(roleName).Result;

                    // modeldeki roleid ile role değişkenindeki id aynı değilse rol değişikliği yapılacak
                    if (role.Id != model.RoleId)
                    {
                        var removeResult = _userManager.RemoveFromRoleAsync(member, roleName).Result;
                        AppRole newRole = _roleManager.FindByIdAsync(model.RoleId).Result;
                        if (_userManager.AddToRoleAsync(member, newRole.Name).Result.Succeeded)
                        {
                            TempData["EditUserSuccessMessage"] += $"\n{roleName} rolü kullanıcıdan silindi! \n{newRole.Name} rolü kullanıcıya eklendi!";

                        }
                    }



                    return RedirectToAction("AllUsers", "Admin", new { area = "Manager" });
                }
                else
                {
                    ModelState.AddModelError("", "Güncelleme başarısız! Tekrar deneyiniz!");
                    return View(model);
                }
            }

			catch (Exception ex)
			{
				TempData["EditUserErrorMessage"] = "Kullanıcı düzenle sayfasında beklenmedik bir hata oluştu!";
				return RedirectToAction("AllUsers", "Admin", new { area = "Manager" });
			}
		}
		
		[HttpGet]
		public IActionResult BranchEdit(int branchId)
		{
			try
			{
				if (branchId <= 0)
				{
					ModelState.AddModelError("","Error");
					return View(new BranchVM());
				}


				var branch = _branchManager.GetByConditions(x => x.Id == branchId).Data;

				if (branch == null)
				{
					ModelState.AddModelError("","Error");
					return View(new BranchVM());
				}

				var city = _cityManager.GetById(branch.District.CityId).Data;

				branch.District.City = city;

				return View(branch);

			}
			catch (Exception e)
			{
				ModelState.AddModelError("","Error");
				return View(new BranchVM());
			}
		}

		[HttpPost]
		public IActionResult BranchEdit(BranchVM model)
		{
			try
			{
				var branch = _branchManager.GetByConditions(x => x.Id == model.Id).Data;
				if (branch == null)
				{
					ModelState.AddModelError("","Error");
					return View(model);
				}

				branch.Name = model.Name;
				branch.Description = model.Description;

				if (!_branchManager.Update(branch).IsSuccess)
				{
					ModelState.AddModelError("","Error");
					return View(model);
				}

				TempData["BranchEditSuccessMessage"] = $"{model.District.City.Name} / {model.District.Name} / {model.Name} adli sube guncellendi";
				return RedirectToAction("AllBranches", "Admin", new { area = "Manager" });
			}
			catch (Exception e)
			{
				ModelState.AddModelError("","Error");
				return View(model);
			}
		}

		
		


    }
}
