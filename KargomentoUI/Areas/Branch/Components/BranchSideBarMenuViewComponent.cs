using Microsoft.AspNetCore.Mvc;

namespace KargomentoUI.Areas.Branch.Components
{
    public class BranchSideBarMenuViewComponent: ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
            
        }
    }
}
