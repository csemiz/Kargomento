using KargomentoBL.InterfacesOfManagers;
using KargomentoEL.ViewModels;
using KargomentoUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KargomentoUI.Controllers
{

    public class HomeController : Controller
    {
        private readonly ICargoStatusProcessManager _cargoStatusProcessManager;

        public HomeController(ICargoStatusProcessManager cargoStatusProcessManager)
        {
            _cargoStatusProcessManager = cargoStatusProcessManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CargoStatus(CargoStatusProcessVM model)
        {
            var cargoStatus = _cargoStatusProcessManager.GetAll(x => x.CargoId == model.CargoId).Data;
            return View(cargoStatus);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}