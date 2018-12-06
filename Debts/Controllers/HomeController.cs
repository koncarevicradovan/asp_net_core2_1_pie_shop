using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Configuration;
using Debts.Models;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Debts.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;
        private readonly MyOptions _options;

        public HomeController(IPieRepository pieRepository, IOptionsMonitor<MyOptions> optionsAccessor)
        {
            _pieRepository = pieRepository;
            _options = optionsAccessor.CurrentValue;
        }

        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(x=>x.Name);
            var homeViewModel = new HomeViewModel()
            {
                Title = _options.Title,
                Pies = pies.ToList()
            };
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie==null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}