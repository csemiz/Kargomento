using Microsoft.AspNetCore.Mvc;

namespace KargomentoUI.Areas.Manager.Components;

public class ManagerSideBarMenuViewComponent: ViewComponent
{

    public IViewComponentResult Invoke()
    {

        return View();
            
    }
}