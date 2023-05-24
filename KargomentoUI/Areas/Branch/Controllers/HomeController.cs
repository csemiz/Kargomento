using KargomentoBL.InterfacesOfManagers;
using KargomentoEL.Constants;
using KargomentoEL.IdentityModels;
using KargomentoEL.Models;
using KargomentoEL.ResultModels;
using KargomentoEL.ViewModels;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;
using System.Text;

namespace KargomentoUI.Areas.Branch.Controllers
{
    [Area("Branch")]
    [Route("sube/[Controller]/[Action]/{id?}")]
   // [Authorize(Roles = "Employee")]
    public class HomeController : Controller
    {
        private readonly ICityManager _cityManager;
        private readonly ICustomerManager _customerManager;
        private readonly ICargoManager _cargoManager;
        private readonly ICargoStatusProcessManager _cargoStatusProcessManager;
        private readonly ICargoStatusManager _cargoStatusManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeBranchManager _employeeBranchManager;
        private readonly IDistrictManager _districtManager;
        private readonly IBranchManager _branchManager;
        private readonly ICargoPayTypesManager _cargoPayTypesManager;

        public HomeController(ICityManager cityManager, ICustomerManager customerManager, ICargoManager cargoManager, ICargoStatusProcessManager cargoStatusProcessManager, ICargoStatusManager cargoStatusManager, UserManager<AppUser> userManager, IEmployeeBranchManager employeeBranchManager, IDistrictManager districtManager, IBranchManager branchManager, ICargoPayTypesManager cargoPayTypesManager)
        {
            _cityManager = cityManager;
            _customerManager = customerManager;
            _cargoManager = cargoManager;
            _cargoStatusProcessManager = cargoStatusProcessManager;
            _cargoStatusManager = cargoStatusManager;
            _userManager = userManager;
            _employeeBranchManager = employeeBranchManager;
            _districtManager = districtManager;
            _branchManager = branchManager;
            _cargoPayTypesManager = cargoPayTypesManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCargo()
        {

            try
            {
                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                ViewBag.CargoPayTypes = _cargoPayTypesManager.GetAll(x => !x.IsRemoved).Data;
                var model = new CargoVM();
                model.Sender = new CustomerVM();
                model.Receiver = new CustomerVM();
                model.ReceiverBranch = new BranchVM();
                model.SenderBranch = new BranchVM();
                model.CargoPayTypes = new CargoPayTypesVM();
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.Cities = new List<CityVM>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateCargo(CargoVM model)
        {

            try
            {

                ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
                ViewBag.CargoPayTypes = _cargoPayTypesManager.GetAll(x => !x.IsRemoved).Data;               
                var user = _userManager.FindByNameAsync(TempData["LoggedInUsername"].ToString()).Result;
                var senderBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == user.Id).Data;

                var sender = _customerManager.GetById(model.Sender.Id).Data;
                if (sender == null)
                {
                    //senderdaki customer tablosuna kaydediceksin
                    CustomerVM c = new CustomerVM()
                    {
                        Id = model.Sender.Id,
                        Name = model.Sender.Name,
                        Surname = model.Sender.Surname,
                        Email = model.Sender.Email,
                        Phone = model.Sender.Phone,
                        CreatedDate = DateTime.Now,
                        IsRemoved = false
                    };

                   var customerResult = _customerManager.Add(c);
                }

                var receiver = _customerManager.GetById(model.Receiver.Id).Data;
                if (receiver == null)
                {
                    //alıcı customer tablosuna kaydediceksin
                    CustomerVM r = new CustomerVM()
                    {
                        Id = model.Receiver.Id,
                        Name = model.Receiver.Name,
                        Surname = model.Receiver.Surname,
                        Email = model.Receiver.Email,
                        Phone = model.Receiver.Phone,
                        CreatedDate = DateTime.Now,
                        IsRemoved = false
                    };

                    var customerResult = _customerManager.Add(r);
                }

                //gönderici
                //senderBranch
                var senderDistrict = _districtManager.GetByConditions(x => x.Id == senderBranch.Branch.DistrictId).Data;
                var senderPlate = senderDistrict.City.PlateCode.Length == 1 ? $"0{senderDistrict.City.PlateCode}" : senderDistrict.City.PlateCode;


                //alıcı
                var branchReceiver = _branchManager.GetByConditions(x => x.Id == model.ReceiverBranchId).Data;
                var cityReceiver = _cityManager.GetByConditions(x => x.Id == branchReceiver.District.CityId).Data;
                var receiverPlate = cityReceiver.PlateCode.Length == 1 ? $"0{cityReceiver.PlateCode}" : cityReceiver.PlateCode;


                CargoVM cargo = new CargoVM()
                {
                    ReceiverAddressDetails = model.ReceiverAddressDetails,
                    CreatedDate = DateTime.Now,
                    ReceiverBranchId = model.ReceiverBranchId,
                    SenderBranchId = senderBranch.BranchId, // login olan employeenin çalıştığı şubenin idsi
                    CargoPayTypeId = model.CargoPayTypeId,
                    Size = model.Size,
                    Price = 0,
                    IsRemoved = false,
                    ReceiverId = model.Receiver.Id,
                    SenderId = model.Sender.Id, // login olan employeenin çalıştığı şubenin idsi
                    //Kargo Takip No:
                    //2305221344493425
                    //yil ay gun saat dak saniye çıkış şubesi plaka varış şubesi plaka
                    //yil ay gun saat dak saniye çıkış şubesi plaka varış şubesi plaka
                    Id = $"{DateTime.Now.ToString("yyMMddHHmmss")}{senderPlate}{receiverPlate}"
                };

                var cargoResult = _cargoManager.Add(cargo);
                if (cargoResult.IsSuccess)
                {
                    //kargoya durum ekleyeceğiz
                    CargoStatusProcessVM process = new CargoStatusProcessVM()
                    {
                        CargoId = cargoResult.Data.Id,
                        EmployeeId = user.Id, // login olan employeenin çalıştığı şubenin idsi,
                        CreatedDate = DateTime.Now,
                        IsRemoved = false,
                        CargoStatusId=_cargoStatusManager.GetByConditions(x=>x.StatusName== ConstantDatas.CARGO_STATUS_CARGO_ACCEPTED).Data.Id
                    };
                    _cargoStatusProcessManager.Add(process);
                    TempData["CargoTrackingNumber"] = $"Kargo takip numarası oluştu : {cargoResult.Data.Id}";
                    return RedirectToAction("Index","Home", new {area="Branch"});
                }
                ModelState.AddModelError("", "Kargo oluşturulamadı! Tekrar deneyiniz!");

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult OutgoingCargo()
        {
			//   var user = _userManager.FindByNameAsync(HttpContext.User.Identity?.Name).Result;   //authorize henüz olmadığı için kullanamdım
			var user = _userManager.FindByNameAsync(TempData["LoggedInUsername"].ToString()).Result;
			var employeeBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == user.Id).Data;

            var outgoings = _cargoManager.GetAll(x => x.SenderBranchId == employeeBranch.BranchId).Data.ToList();

			return View(outgoings);
        }

        public IActionResult IncomingCargo()
        {
            try
            {
				//   var user = _userManager.FindByNameAsync(HttpContext.User.Identity?.Name).Result;   //authorize henüz olmadığı için kullanamdım

				var user = _userManager.FindByNameAsync(TempData["LoggedInUsername"].ToString()).Result;
				var employeeBranch = _employeeBranchManager.GetByConditions(x => x.EmployeeId == user.Id).Data;

				var incomingcargos = _cargoManager.GetAll(x => x.ReceiverBranchId == employeeBranch.BranchId).Data.ToList();

				return View(incomingcargos);
			}
            catch (Exception ex)
            {

                return View();
            }
        }

		[HttpGet]
		public IActionResult AssignAction(string? cargoId)
		{
			try
			{
               var allCargoStatus = _cargoStatusManager.GetAll().Data;
                if (string.IsNullOrEmpty(cargoId))
                {
                    ModelState.AddModelError("", "cargo id gelmediği için bilgiler yüklenemedi!");
                    return View(new CargoVM());
                }

                var cargo = _cargoManager.GetByConditions(x => x.Id == cargoId).Data;
                if (cargo==null)
                {
                    ModelState.AddModelError("", "Kargo bulunamadı! Tekrar deneyiniz!");
                    return View(new CargoVM());
                }
                cargo.CargoStatusProcess = new List<CargoStatusProcessVM>();

                cargo.CargoStatusProcess = _cargoStatusProcessManager.GetAll(x => x.CargoId == cargoId).Data.ToList().OrderByDescending(x=> x.Id).ToList();


                List<CargoStatusVM> status = new List<CargoStatusVM>();
                // Aşağıdaki algoritma malesef çalışmıyor.... tekrar düşünüp düzenleyeceğiz
                foreach (var item in allCargoStatus)
                {
                    foreach (var subItem in cargo.CargoStatusProcess)
                    {
                        if (!allCargoStatus.Contains(subItem.CargoStatus))
                        {
                            if (status.Count(x=> x.StatusName==item.StatusName)==0)
                            {
                                status.Add(item);
                            }
                        }
                    }
                }
                ViewBag.AllCargoStatus = status;

				return View(cargo);
			}
			catch (Exception ex)
			{

				return View();
			}
		}

		[HttpPost]
		public IActionResult AssignAction(CargoVM model)
		{
			try
			{
				//ViewBag.Cities = _cityManager.GetAll(x => !x.IsRemoved).Data;
				//ViewBag.Districts = _districtManager.GetAll(x => !x.IsRemoved && x.CityId == model.Sender.District.City.Id).Data;
				//ViewBag.Branches = _branchManager.GetAll(x => x. == model.Id).Data;
				//var cargoaction = _employeeBranchManager.GetByConditions(x => x.EmployeeId == model.SenderBranchId).Data;
				//if (cargoaction == null)
				//{
				//	ModelState.AddModelError("", "error");
				//	return View(model);
				//}
				//cargoaction.Branch = null;
				//cargoaction.BranchId = model.BranchId;
				//cargoaction.CreatedDate = DateTime.Now;
				//cargoaction.Salary = 20000;
				//var result = _employeeBranchManager.Update(employeeBranch);
				return RedirectToAction("IncomingCargo", "Home");


			}
			catch (Exception ex)
			{
				return View(model);
			}

			return View();
		}

	}
}
