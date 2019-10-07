using OfakimTestProject.Services;
using System.Threading;
using System.Web.Mvc;

namespace OfakimTestProject.Controllers
{
    public class DataController : Controller
    {
        public ActionResult GetData()
        {
            var model = DataService.GetData();
            new Thread(() => { DataService.DeleteOldValues(); }).Start();
            return View(model);
        }
    }
}