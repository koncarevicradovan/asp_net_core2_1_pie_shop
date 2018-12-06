using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Debts.Configuration;
using Debts.Models;
using Debts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Debts.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;
        private readonly MyOptions _options;
        private readonly ILogger _logger;

        public HomeController(IPieRepository pieRepository, IOptionsMonitor<MyOptions> optionsAccessor, ILogger<HomeController> logger)
        {
            _pieRepository = pieRepository;
            _options = optionsAccessor.CurrentValue;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index view hit.");
            HomeViewModel homeViewModel = new HomeViewModel();
            try
            {
                var pies = _pieRepository.GetAllPies().OrderBy(x => x.Name);
                homeViewModel = new HomeViewModel()
                {
                    Title = _options.Title,
                    Pies = pies.ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error loading pies from db. ex: {0}", ex.StackTrace.ToString());
            }
            
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