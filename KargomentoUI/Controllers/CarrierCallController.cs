using KargomentoBL.InterfacesOfManagers;
using KargomentoEL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KargomentoUI.Controllers
{
    public class CarrierCallController : Controller
    {
        private readonly ICityManager _cityManager;
        private readonly IDistrictManager _districtManager;
        private readonly IBranchManager _branchManager;
        private readonly ICustomerManager _customerManager;
        private readonly ICarrierCallManager _carriercallManager;

        public CarrierCallController(ICityManager cityManager, IDistrictManager districtManager, IBranchManager branchManager, ICustomerManager customerManager, ICarrierCallManager carriercallManager)
        {
            _cityManager = cityManager;
            _districtManager = districtManager;
            _branchManager = branchManager;
            _customerManager = customerManager;
            _carriercallManager = carriercallManager;
        }

        [HttpGet]
        public IActionResult CallCarrier()
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                return View(new CarrierCallVM { Customer=new CustomerVM()});
            }
            catch (Exception ex)
            {

                ViewBag.Cities = new List<CityVM>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult CallCarrier(CarrierCallVM model)
        {
            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                model.Customer.Id = model.CustomerId;

                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("", "Gerekli alanları lütfen doldurunuz!");
                //    return View(model);
                //}
                var sameCustemer = _customerManager.GetByConditions(x => x.Id == model.CustomerId).Data;
                if (sameCustemer == null)
                {
                    CustomerVM customer = new CustomerVM()
                    {
                        CreatedDate = DateTime.Now,
                        IsRemoved = false,
                        Email = model.Customer.Email,
                        Id = model.CustomerId,
                        Name = model.Customer.Name,
                        Surname = model.Customer.Surname,
                        Phone = model.Customer.Phone,
                    };
                    _customerManager.Add(customer);
                }
                CarrierCallVM carriercall = new CarrierCallVM()
                {
                    CustomerId = model.CustomerId,
                    BranchId = model.BranchId,
                    CustomerAddressDetails = model.CustomerAddressDetails,
                    CreatedDate = DateTime.Now,
                    IsRemoved = false,
                };
                _carriercallManager.Add(carriercall);
                //tempdata
                return RedirectToAction("Home", "Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public JsonResult GetCityDistricts(int id)
        {
            try
            {
                var data = _districtManager.GetAll(x => x.CityId == id && !x.IsRemoved).Data;
                if (data == null)
                {
                    return Json(new { issuccess = false, message = "İlçeler bulunamadı!" });
                }
                return Json(new { issuccess = true, message = "İlçeler geldi!", data });

            }
            catch (Exception ex)
            {
                return Json(new { issuccess = false, message = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetDistrictsBranch(int id)
        {
            try
            {
                var data = _branchManager.GetAll(x => x.DistrictId == id && !x.IsRemoved).Data;
                if (data == null)
                {
                    return Json(new { issuccess = false, message = "İlçeler bulunamadı!" });
                }
                return Json(new { issuccess = true, message = "İlçeler geldi!", data });

            }
            catch (Exception ex)
            {
                return Json(new { issuccess = false, message = ex.Message });
            }
        }
    }
}
