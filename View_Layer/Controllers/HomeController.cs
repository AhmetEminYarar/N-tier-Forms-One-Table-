using Data_Access_Layer.Repostories;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.Entities;
using System.Diagnostics;
using View_Layer.Models;

namespace View_Layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository<Customer> _repository=new Repository<Customer>();   

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            return View(await _repository.VeriCek());
        }
        [HttpPost]
        public async Task<IActionResult> Index( string FirstName, string LastName, char Gender,int YearOfBirth, string StreetAddress, string PostalCode, string City)
        {
            Customer customer = new Customer();
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.Gender = Gender;
            customer.YearOfBirth = YearOfBirth;
            customer.StreetAddress = StreetAddress;
            customer.PostalCode = PostalCode;
            customer.City = City;
            await _repository.VeriEkle(customer);
            return RedirectToAction("Index");
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