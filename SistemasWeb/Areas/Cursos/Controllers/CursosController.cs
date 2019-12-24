using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Areas.Cursos.Models;
using SistemasWeb.Data;
using SistemasWeb.Library;
using SistemasWeb.Models;

namespace SistemasWeb.Areas.Cursos.Controllers
{
    [Area("Cursos")]
    public class CursosController : Controller
    {

        // CONSTRUCCION DE OBJETOS
        private LCursos _curso;
        private LCategorias _lcategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCursos> models;
        private static IdentityError identityError;
        private ApplicationDbContext _context;


        // Se produce la inyeccion de la interface "IWebHostEnvironment". Se utiliza para poder obtner la direccion de la aplicacion y el host de la aplicacion
        public CursosController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager,IWebHostEnvironment environment)

        {
            // INICIALIZACION DE OBJETOS
            _signInManager = signInManager;
            _curso = new LCursos(context, environment);
            _lcategoria = new LCategorias(context);
        }
        public IActionResult Cursos( int id, String search, int Registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _curso.geTCursos(Search);
                models = new DataPaginador<TCursos>
                {
                   
                    Categorias = _lcategoria.getTCategoria(),
                    Input = new TCursos()
                };
                return View(models);
            }
            else
            {
                return Redirect("/Home/Index");
            }

        }

        //Este objeto contiene "Input" . Este metodo se ejecutara solo cada vez que hagamos una peticion por Post.
        //Esto quiere decir que solo se ejecutara cuando se de el Post del AJAX que se encuentra en el archivo
        //"Cursos.js"

        [HttpPost]
        public String GetCurso(DataPaginador<TCursos> model)
        {
            if (model.Input.Nombre != null && model.Input.Descripcion != null && model.Input.CategoriaID > 0)
            {
                // Si esta propiedad es igual a 0

                if (model.Input.Horas.Equals(0))
                {
                    return "Ingrese la cantidad de horas del Curso";

                }
                else 
                {
                    if (model.Input.Costo.Equals(0.00M))
                    {
                        return "Ingrese el costo del Curso";

                    }
                    else 
                    {
                        var data = _curso.RegistrarCursoAsync(model);
                        // Deserializamos el objeto para poder convertirlo en String y recogerlo. Recordemos que
                        // hay que devolver un String al metodo "GetCurso"

                        return JsonConvert.SerializeObject(data.Result);
                    
                    }
                
                }

            }
            else 
            {
                return "LLene los campos requeridos";
            }

            return "Hola";
        }
    }
}