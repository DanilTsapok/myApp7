using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace myApp.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Download()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Download(string firstName, string secondName, string fileName )
        {
            string encodefileName = HttpUtility.UrlEncode(fileName);
            string fileText = $"Ім'я {firstName}\n Прізвище: {secondName}";
            byte[]bytes = Encoding.UTF8.GetBytes(fileText);
            Response.Headers.Add("Content-Disposition", $"attachment; filename={encodefileName}.txt");
            Response.ContentType = "text/plain";
            return File(bytes, "text/plain");
        }
  
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}