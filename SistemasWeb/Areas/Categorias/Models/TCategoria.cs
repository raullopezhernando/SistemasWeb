﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Areas.Categorias.Models
{
    public class TCategoria
    {
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; } = true;
        // Cada categoria va a llevar una coleccion de Cursos
        // public ICollection<TCursos> Cursos { get; set; }
    }
}
