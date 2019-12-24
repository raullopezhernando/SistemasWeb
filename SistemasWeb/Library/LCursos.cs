using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Areas.Cursos.Models;
using SistemasWeb.Data;
using SistemasWeb.Models;

namespace SistemasWeb.Library
{
    public class LCursos
    {
        private Uploadimage _image;
        private ApplicationDbContext context;
        private IWebHostEnvironment environment;

        public LCursos(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            // Inicializacion de los objetos

            this.context = context;
            this.environment = environment;
            _image = new Uploadimage();
        }
        public async Task<IdentityError> RegistrarCursoAsync(DataPaginador<TCursos> model)
        {
            IdentityError identityError;
            try
            {
                // El metodo "ByteAvatarImageAsync" esta sincronizado con otra tarea que esta haciendo la copia
                // de la imagen 
                var imageByte = await _image.ByteAvatarImageAsync(model.AvatarImage, environment);
                var curso = new TCursos
                {
                    Nombre = model.Input.Nombre,
                    Descripcion = model.Input.Descripcion,
                    Horas = model.Input.Horas,
                    Costo = model.Input.Costo,
                    Estado = model.Input.Estado,
                    Image = imageByte,
                    CategoriaID = model.Input.CategoriaID
                };
                context.Add(curso); // Agregamos el objeto Curso a la tabla TCursos de la base de datos
                context.SaveChanges();
                identityError = new IdentityError { Code = "Done" };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }

        internal object GeTCursos(object search)
        {
            List<TCursos> listCursos;

            if (search == null)
            {
                listCursos = context._TCursos.ToList();
            }
            else 
            {
                listCursos = context._TCursos.Where(c => c.Nombre.StartsWith(search)).toList();
            }
        }
    }
}