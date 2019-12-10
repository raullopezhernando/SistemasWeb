using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Controllers;
using SistemasWeb.Data;
using SistemasWeb.Library;
using SistemasWeb.Models;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    public class CategoriasController : Controller
    {
        private TCategoria _categoria;
        private LCategorias _lcategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;
        public CategoriasController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lcategoria = new LCategorias(context);
        }
        public IActionResult Categoria()
        {
            // Si un usuario logeado ha accedido a la aplicacion entrara aqui
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPaginador<TCategoria>
                {
                    Input = new TCategoria()
                };
                return View(models);
            }
            else
            {
                // Si el login es incorrecto se le redirige a la vista Index del HomeController
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

        }
    }
}