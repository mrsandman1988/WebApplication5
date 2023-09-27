using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PhoneDbContext _phoneDbContext;
        public FileController(IWebHostEnvironment webHostEnvironment, PhoneDbContext phoneDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _phoneDbContext = phoneDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Phone phone, IFormFile Image)
        {


            phone.FileName = "-";
            _phoneDbContext.Phones.Add(phone);
            _phoneDbContext.SaveChanges();
            var filename = phone.Name.Replace(" ", "_") +  "_" + phone.Id.ToString();
            string path = _webHostEnvironment.WebRootPath + $"/Images/{filename}";
            using var stream = new FileStream(path, FileMode.Create);
            Image.CopyTo(stream);
            phone.FileName = filename;
            _phoneDbContext.SaveChanges();
            return View();
        }

        public IActionResult List()
        {
            var phones = _phoneDbContext.Phones.ToList();
            return View(phones);
        }
    }
}
