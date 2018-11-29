using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Models;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Debts.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(x=>x.Name);
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to pie shop!",
                Pies = pies.ToList()
            };
            return View(homeViewModel);
        }
    }
}