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
        public List<T> List { get; set; }
        public string Pagi_info { get; set; }
        public string Pagi_navegacion { get; set; }
        public T input { get; set; }
        public int Registros { get; set; }
        public string Search { get; set; }
        public string ErrorMessage { get; set; }


    }
}
