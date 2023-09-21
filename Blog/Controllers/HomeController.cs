using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataLayer;
using EntityLayer;
using BussinessLayer.Concrate;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context db = new Context();
        BlogYazilariManager _yazilar = new BlogYazilariManager();
        BlogYazilari _yazi;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(db.tbl_BlogYazilari.OrderByDescending(x=>x.Id));
        }

        public IActionResult DevaminiOku(int id)
        {
            _yazi = _yazilar.GetById(id);
            _yazi.TikSayisi += 1;
            _yazilar.Update(_yazi);
            return View(_yazi);
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
    }
}