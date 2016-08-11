using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class AutomationController : Controller
    {
        // GET: Automation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RunTestsResult(string tests)
        {
            ExcelParser.Input.Start(tests);
            return View();
        }
    }
}