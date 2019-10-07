using OfakimTestProject.DAL;
using OfakimTestProject.Services;
using System.Linq;
using System.Web.Mvc;

namespace OfakimTestProject.Controllers
{
    public class OfakimController : Controller
    {

        public ActionResult Index()
        {
            var model = DataService.GetMainModel();
            return View(model);
        }

    }
}