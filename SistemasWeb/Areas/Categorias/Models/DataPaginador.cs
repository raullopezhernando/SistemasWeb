using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Areas.Categorias.Models
{
    // Esta clase al estar en "Models" es accesible desde todos los lugares
    // Aplicandole la letra "T" hacemos que la clase sea generica (
    public class DataPaginador<T>
    {
        public List<T> List { get; set; } // Esta coleccion de la clase  List va a contener una coleccion de datos de la clase TCategorias
        public string Pagi_info { get; set; }
        public string Pagi_navegacion { get; set; }
        public T Input { get; set; } // Este objeto lo vamos a inicializar con la clase TCategorias
        public int Registros { get; set; }
        public string Search { get; set; }
        // Interface que nos ayuda a capturar la imagen desde el directorio del PC
        public IFormFile AvatarImage { get; set; }
        public string ErrorMessage { get; set; }

        public IEnumerable<SelectListItem> Categorias { get; set; }

    }
}
