using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Data;

namespace SistemasWeb.Library
{
    public class LCategorias
    {
        private ApplicationDbContext _context;

        public LCategorias(ApplicationDbContext context)
        {
            _context = context;
        }
        public IdentityError RegistrarCategoria(TCategoria categoria)
        {
            IdentityError identityError;
            try
            {
                // Cuando el parametro esta a 0 es que nos encontramos en "Modo de Registrar una Categoria"
                // Si vale 0 no se puede actualizar sino que agregara ya que al valer 0 la CategoriaID
                // esta no existe en la base de datos. recordemos que el "CategoriaID" es un autoincrementable desde 1
                // en la base de datos

                if (categoria.CategoriaID.Equals(0))
                {
                    _context.Add(categoria);
                }
                else
                // Estamos en modo de "Actualizar Categoria" ya que la "CategoriaID" sera mayor que 0
                {
                    _context.Update(categoria);
                }
               
                _context.SaveChanges();
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
        public List<TCategoria> getTCategoria(String valor)
        {
            List<TCategoria> listCategoria;
            if (valor == null)
            {
                listCategoria = _context._TCategoria.ToList();
            }
            else
            {
                listCategoria = _context._TCategoria.Where(c => c.Nombre.StartsWith(valor)).ToList();
            }
            return listCategoria;
        }

        // El modificador "internal" especifica que este metodo puede ser accedido desde cualquier clase
        internal IdentityError UpdateEstado(int id) 
        {
            IdentityError identityError;

            try
            {
                // En esta sentencia linq obtendremos aquella categoria en la cual el "CategoriaID" sea igual al 
                // "id" que nos venga por parametro . Como solo vamos a obtnere un elemento aunque hayamos usado "ToList()"
                // utilizamos "ElementAt(0)" para coger dicho primer elemento

                var categoria = _context._TCategoria.Where(c => c.CategoriaID.Equals(id)).ToList().ElementAt(0);
                // Operador Ternario
                //Obtenemos el dato de Estado . Si la propiedad de estado es True eso significa que queremos desactivar
                // esa categoria por eso el "false" y al reves si la propiedad de estado esta a "false" eso significa
                // que queremos activar nuestra caregoria de hay ese "true"
                categoria.Estado = categoria.Estado ? false : true;
                int data = Convert.ToUInt16("a");
                _context.Update(categoria); // Actualizamos
                _context.SaveChanges();// Salvamos cambios en las tablas en general
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


