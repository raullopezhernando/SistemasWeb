using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SistemasWeb.Areas.Principal.Controllers
{
    // Para poder utilizar el controlador hay que especificarle que se encuentra en la area principal
    // Esto se realiza con el siguiente atributo

   [Area("Principal")]
    public class PrincipalController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}