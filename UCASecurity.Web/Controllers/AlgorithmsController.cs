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
        public IActionResult RSAEncrypt(string key, string text)
        {
            var rsa = new RSA();
            var result = rsa.Encrypt(text, key);
            return Json(result);
        }
        [Route("/api/rsa/decrypt")]
        public IActionResult RSADecrypt(string key, string cipher)
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
        public IActionResult Caesar()
        {
            return View();
        }
        [Route("/api/caesar/encrypt")]
        public IActionResult CaesarEncrypt(int key, string text)
        {
            Caesar ceaser = new Caesar();
            var result = ceaser.Encrypt(text, key);
            return Json(result);
        }

        [Route("/api/caesar/decrypt")]
        public IActionResult CaesarDecrypt(int key, string cipher)
        {
            Caesar ceaser = new Caesar();
            var result = ceaser.Decrypt(cipher, key);
            return Json(result);
        }
        public IActionResult BlowFish()
        {
            return View();
        }
        [Route("/api/blowfish/encrypt")]
        public IActionResult BlowFishEncrypt(string key, string text)
        {
            BlowFish ceaser = new BlowFish();
            var result = ceaser.Encrypt(text, key);
            return Json(result);
        }

        [Route("/api/blowfish/decrypt")]
        public IActionResult BlowFishDecrypt(string key, string cipher)
        {
            BlowFish ceaser = new BlowFish();
            var result = ceaser.Decrypt(cipher, key);
            return Json(result);
        }
        public IActionResult Vigenare()
        {
            return View();
        }
        [Route("/api/vigenare/encrypt")]
        public IActionResult VigenareEncrypt(string key, string text)
        {
            Vigenare vigenare = new Vigenare();
            var result = vigenare.Encrypt(text, key);
            return Json(result);
        }

        [Route("/api/vigenare/decrypt")]
        public IActionResult VigenareDecrypt(string key, string cipher)
        {
            Vigenare vigenare = new Vigenare();
            var result = vigenare.Decrypt(cipher, key);
            return Json(result);
        }
        public IActionResult AES()
        {
            return View();
        }
        [Route("/api/aes/encrypt")]
        public IActionResult AESEncrypt(string key, string text, string algorithm)
        {
            dynamic aes = new AES(algorithm);
            if (algorithm.Equals("CBC") || algorithm.Equals("ECB"))
                aes = new AES2(algorithm);
            var result = aes.Encrypt(text, key);
            return Json(result);
        }

        [Route("/api/aes/decrypt")]
        public IActionResult AESDecrypt(string key, string cipher, string algorithm)
        {
            dynamic aes = new AES(algorithm);
            if (algorithm.Equals("CBC") || algorithm.Equals("ECB"))
                aes = new AES2(algorithm);
            var result = aes.Decrypt(cipher, key);
            return Json(result);
        }
    }
}
