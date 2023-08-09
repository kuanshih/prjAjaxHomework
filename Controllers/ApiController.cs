using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjAjaxHomework.Models;

namespace prjAjaxHomework.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext dbContext, IWebHostEnvironment host)
        {
            _context = dbContext;
            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        }
        public IActionResult District(string city)
        {
            var districts = _context.Address.Where(a => a.City == city).Select(c => c.SiteId).Distinct();
            return Json(districts);

        }
        public IActionResult Roads(string siteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == siteId).Select(r => r.Road).Distinct();
            return Json(roads);
        }
    }
}
