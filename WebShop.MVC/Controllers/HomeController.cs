using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;
using WebShop.MVC.Models;
using WebShop.MVC.ViewModels.Home;

namespace WebShop.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ISessionService _sessionService;


        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ISessionService sessionService)
        {
            _logger = logger;
            _productRepository = productRepository;
            _sessionService = sessionService;
        }

        [Route("/")]
        [Route("/home")]
        [Route("/home/index")]
        [Route("/home/index/{categoryName:alpha}")]
        public IActionResult Index(string? categoryName)
        {
            if(categoryName is not null)
            {
                ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), categoryName);

                _sessionService.SetFilter(null, null, category);
            }

            var products = _productRepository.WithFilter();

            HomeIndexVM vm = new()
            {
                Products = products
            };

            return View(model: vm);

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