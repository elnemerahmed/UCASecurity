﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UCASecurity.Encryption.Algorithms;
using UCASecurity.Web.ViewModels;

namespace UCASecurity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Symmetric()
        {
            var Classic = new List<ItemViewModel>();
            Classic.Add(new ItemViewModel() { Controller = "Algorithms", Action = "Caesar", Title = "Algorithms_Caesar_Title", Healthy = new Caesar().Health() });
            Classic.Add(new ItemViewModel() { Controller = "Algorithms", Action = "Vigenare", Title = "Algorithms_Vigenare_Title", Healthy = new Vigenare().Health() });
            Classic.Add(new ItemViewModel() { Controller = "Algorithms", Action = "PlayFair", Title = "Algorithms_PlayFair_Title", Healthy = new PlayFair().Health() });
            Classic.Add(new ItemViewModel() { Controller = "Algorithms", Action = "RailFence", Title = "Algorithms_RailFence_Title", Healthy = new RailFence().Health() });

            var Advanced = new List<ItemViewModel>();
            Advanced.Add(new ItemViewModel() { Controller = "Algorithms", Action = "AES", Title = "Algorithms_AES_Title", Healthy = new AES1("AES/OFB/NoPadding").Health() && new AES2("CBC", "PKCS7").Health() });
            Advanced.Add(new ItemViewModel() { Controller = "Algorithms", Action = "DES", Title = "Algorithms_DES_Title", Healthy = new DES("CBC", "PKCS7").Health() });
            Advanced.Add(new ItemViewModel() { Controller = "Algorithms", Action = "BlowFish", Title = "Algorithms_BlowFish_Title", Healthy = new BlowFish().Health() });
            Advanced.Add(new ItemViewModel() { Controller = "Algorithms", Action = "RC2", Title = "Algorithms_RC2_Title", Healthy = new RC2().Health() });

            ViewBag.Classic = Classic;
            ViewBag.Advanced = Advanced;
            return View();
        }

        public IActionResult Asymmetric()
        {
            var Asymmetric = new List<ItemViewModel>();
            Asymmetric.Add(new ItemViewModel() { Controller = "Algorithms", Action = "RSA", Title = "Algorithms_RSA_Title", Healthy = new RSA().Health() });

            ViewBag.Asymmetric = Asymmetric;
            return View();
        }
        public IActionResult Math()
        {
            var Math = new List<ItemViewModel>();
            Math.Add(new ItemViewModel() { Controller = "Math", Action = "PasswordStrength", Title = "Math_PasswordStrength_Title", Healthy = true });
            Math.Add(new ItemViewModel() { Controller = "Math", Action = "PrimeFactorization", Title = "Math_PrimeFactorization_Title", Healthy = true });
            Math.Add(new ItemViewModel() { Controller = "Math", Action = "PrimeTest", Title = "Math_PrimeTest_Title", Healthy = true });
            Math.Add(new ItemViewModel() { Controller = "Math", Action = "GCD", Title = "Math_GCD_Title", Healthy = true });

            ViewBag.Math = Math;
            return View();
        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }
}
