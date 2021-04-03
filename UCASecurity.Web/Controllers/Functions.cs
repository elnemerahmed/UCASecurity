using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCASecurity.Web.Controllers
{
    public class Functions : Controller
    {
        public IActionResult Hash()
        {
            return View();
        }
    }
}
