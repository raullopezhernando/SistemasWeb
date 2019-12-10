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
        private TCategoria _categoria;
        private LCategoria _lcategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;
        public IActionResult Categoria()
        {
            return View();
        }
    }
}