using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebVendas.Models;

namespace WebVendas.Controllers
{
    public class HomeController : Controller
    {
        // Injeta no construtor do Controller o dbcontext
        //protected ApplicationDbContext Repositorio;

        //public HomeController(ApplicationDbContext repositorio, ILogger<HomeController> logger)
        //{
        //    Repositorio = repositorio;
        //}

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewData["Title"] = "Menu";
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
    }
}
