using Microsoft.AspNetCore.Mvc;

namespace KargomentoUI.Areas.Branch.Components;

public class TopBarMenuViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}