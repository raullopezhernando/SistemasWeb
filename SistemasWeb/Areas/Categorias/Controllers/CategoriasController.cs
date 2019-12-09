using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    public class CategoriasController : Controller
    {
        public IActionResult Categoria()
        {
            return View();
        }
    }
}