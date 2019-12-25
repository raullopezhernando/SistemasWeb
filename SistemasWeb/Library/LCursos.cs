using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            this.context = context;
            this.environment = environment;
            _image = new Uploadimage();
        }
        public async Task<IdentityError> RegistrarCursoAsync(DataPaginador<TCursos> model)
        {
            IdentityError identityError;
            try
            {
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
                context.Add(curso);
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

        internal List<TCursos> getTCursos(string search)
        {
            List<TCursos> listCursos;
            if (search == null)
            {
                listCursos = context._TCursos.ToList();
            }
            else
            {
                listCursos = context._TCursos.Where(c => c.Nombre.StartsWith(search)).ToList();
            }
            return listCursos;
        }

        internal IdentityError UpdateEstado(int id)
        {
            // Para poder definir el tipo de excepcion es necesario el objeto "IdentityError"
            IdentityError identityError;
            try
            {
                // Si en la columna Cursos hay una id igual a la que viene por parametro guardamos el curso.
                // Informacion dependiendo de la id que me venga por parametro

                var curso = context._TCursos.Where(c => c.CursoID.Equals(id)).ToList().ElementAt(0);
                curso.Estado = curso.Estado ? false : true;
                context.Update(curso); // Actualizar la tabla de Cursos con la informacion del objeto Curso
                context.SaveChanges();// Salvamos los cambios
                identityError = new IdentityError { Description = "Done" };
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


    }
}