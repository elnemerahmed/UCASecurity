using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCASecurity.Encryption.Algorithms;
using UCASecurity.Web.ViewModels;

namespace UCASecurity.Web.Controllers
{
    public class AlgorithmsController : Controller
    {
        public IActionResult RSA()
        {
            return View();
        }
        [Route("/api/rsa/encrypt")]
        public IActionResult RSA_Encrypt(string key, string text)
        {
            var rsa = new RSA();
            var result = rsa.Encrypt(text, key);
            return Json(result);
        }
        [Route("/api/rsa/decrypt")]
        public IActionResult RSA_Decrypt(string key, string cipher)
        {
            var rsa = new RSA();
            var result = rsa.Decrypt(cipher, key);
            return Json(result);
        }
        public IActionResult GenerateRSAKeyPair()
        {
            var keyPair = Encryption.Algorithms.RSA.GenerateKeyPair();
             
            return View(new RSAKeyPairViewModel() { 
                PublicKey = Encryption.Algorithms.RSA.KeyToString(keyPair.payload.Public).payload,
                PrivateKey = Encryption.Algorithms.RSA.KeyToString(keyPair.payload.Private).payload
            });
        }
    }
}
