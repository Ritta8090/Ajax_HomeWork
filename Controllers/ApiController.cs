using Ajax_HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ajax_HomeWork.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        
        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //載入縣市
        public IActionResult Cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        }
        //根據縣市載入鄉鎮區
        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }

        //根據鄉鎮區載入路名
        public IActionResult Roads(string SiteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == SiteId).Select(a => a.Road);
            return Json(roads);
        }
    }
}
