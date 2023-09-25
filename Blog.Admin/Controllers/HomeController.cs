using Blog.Admin.Models;
using BussinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
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

        public IActionResult Yazilar()
        {
            return View(db.tbl_BlogYazilari.OrderByDescending(x=>x.Id));
        }
        public IActionResult YeniYazi()
        {
            ViewBag.TurList = new SelectList(new List<string>
            {
                "Popüler",
                "Yeni",
                "Editörün Seçtiği"
            });

            return View();
        }

       


        [HttpPost]
        public IActionResult YeniYazi(BlogYazilari yazilar, IFormFile resim)
        {
            if (yazilar.TurId == null)
            {
                yazilar.TurId = "Yeni yazı";
            }
           
                if (resim != null && resim.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        resim.CopyTo(memoryStream);
                        yazilar.Resim = memoryStream.ToArray();
                    }
                }


            yazilar.TikSayisi = 0;
                db.tbl_BlogYazilari.Add(yazilar);
                db.SaveChanges();

                return RedirectToAction("Yazilar");
            
        }

        

        int global = 0;

        public IActionResult Guncelle(int id)
        {
            ViewBag.TurList = new SelectList(new List<string>
            {
                "Popüler",
                "Yeni",
                "Editörün Seçtiği"
            });

            _yazi = _yazilar.GetById(id);
            id = global;
            return View(_yazi);
        }

        [HttpPost]
        public IActionResult Guncelle(BlogYazilari yazilar, IFormFile resim)
        {
            if (yazilar.TurId == null)
            {
                yazilar.TurId = "Popüler";
            }
            int id = yazilar.Id;

            byte[] eskiResim = db.tbl_BlogYazilari.FirstOrDefault(x => x.Id == id).Resim;

            if (resim != null && resim.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    resim.CopyTo(memoryStream);
                    yazilar.Resim = memoryStream.ToArray();
                }
            }
            else
            {
                yazilar.Resim = eskiResim;
            }

            _yazilar.Update(yazilar);

            return RedirectToAction("Yazilar");
        }
        public IActionResult ResimSil(int id)
        {
            var yazilar = db.tbl_BlogYazilari.FirstOrDefault(x => x.Id == id);

            if (yazilar != null)
            {
                yazilar.Resim = null;

                // Değişiklikleri kaydedin
                db.SaveChanges();
            }
            return RedirectToAction("Guncelle", new { id = id });
        }
        public IActionResult BlogYaziSil(int id)
        {
            _yazi = _yazilar.GetById(id);
            _yazilar.Delete(_yazi);
            return RedirectToAction("Yazilar");
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