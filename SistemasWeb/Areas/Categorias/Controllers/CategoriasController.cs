using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Library;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    public class CategoriasController : Controller
    {
        private TCategoria _categoria;
        private LCategorias _lcategoria;
        // Clase que maneja los inicios de sesion de la aplicaion
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;
        public IActionResult Categoria()
        {
            return View();
        }
    }
}