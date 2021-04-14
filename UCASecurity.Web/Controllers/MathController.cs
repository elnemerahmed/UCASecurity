using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCASecurity.Encryption.Functions;

namespace UCASecurity.Web.Controllers
{
    public class MathController : Controller
    {
        public IActionResult PrimeFactorization()
        {
            return View();
        }
        [Route("/api/primefactorization")]
        public IActionResult PrimeFactorization(long number)
        {
            var result = Prime.GetFactors(number);
            return Json(result);
        }
        public IActionResult PrimeTest()
        {
            return View();
        }
        [Route("/api/primetest")]
        public IActionResult PrimeTest(long number)
        {
            var result = Prime.isPrime(number);
            return Json(result);
        }
        public IActionResult GCD()
        {
            return View();
        }
        [Route("/api/gcd")]
        public IActionResult GCD(long a, long b)
        {
            var result = Prime.GCD(a, b);
            return Json(result);
        }
        public IActionResult PasswordStrength()
        {
            return View();
        }
        [Route("/api/passwordstrength")]
        public IActionResult PasswordStrength(string password)
        {
            var result = Password.Strength(password);
            return Json(result);
        }
    }
}
