using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Random_Passcode.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Console.WriteLine(HttpContext.Session.GetInt32("Counter") + 1);
            int? x = HttpContext.Session.GetInt32("Counter");
            if(x.HasValue)
            {
                int y = x.Value + 1;
                HttpContext.Session.SetInt32("Counter", y);
            }
            else
            {
                HttpContext.Session.SetInt32("Counter", 1);
            }
            //call function to get a random 14 character string
            ViewBag.RandomString = RandomString();
            ViewBag.Counter = HttpContext.Session.GetInt32("Counter");
            return View();
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
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
        
        public string RandomString()
        {
            string randomString = "";
            string[] possibleChars = new string[]{"0","1","2","3","4","5","6","7","8","9","A","C","B","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
            for (int i = 0; i < 14; i++)
            {
                //get a random number, 0-36
                Random rand = new Random();
                int nextNum = rand.Next(62);
                //create an array of characters
                string nextChar = possibleChars[nextNum];
                randomString += nextChar;
            }
            Console.WriteLine(randomString);
            return randomString;
        }
    }
}
