using Microsoft.AspNetCore.Mvc;

namespace KargomentoUI.Components
{
    public class TopMenuViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
