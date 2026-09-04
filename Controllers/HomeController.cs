using Assessment4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assessment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("name")))
            {
                return RedirectToAction(nameof(TopMelons));
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("top-melons")]
        public IActionResult TopMelons()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("name")))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewData["Melons"] = Melon.mostLovedMelons;

            return View("TopMelons");
        }

        [HttpPost("get-name")]
        public IActionResult GetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("You entered an empty value as your name. Go back and enter your real name.");
            }

            HttpContext.Session.SetString("name", name);
            _logger.LogInformation("Session name set to {Name}", name);

            return RedirectToAction(nameof(TopMelons));
        }

        [HttpPost("love-melon")]
        public IActionResult LoveMelon(string melonName)
        {
            var lovedMelon = Melon.mostLovedMelons.FirstOrDefault(m => m.Name == melonName);

            if (lovedMelon != null)
            {
                lovedMelon.NumLoves++;
                _logger.LogInformation("{MelonName} loved. New total: {NumLoves}", lovedMelon.Name, lovedMelon.NumLoves);
            }

            return View("ThankYou");
        }
    }
}
