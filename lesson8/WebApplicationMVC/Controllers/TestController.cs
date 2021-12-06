using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace WebApplicationMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataToView(string name, int numOfTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumOfTimes"] = numOfTimes;

            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Welcome {name}, NumIs : {numTimes}");
        }
    }
}
