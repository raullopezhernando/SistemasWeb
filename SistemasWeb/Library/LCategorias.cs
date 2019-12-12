﻿using Microsoft.AspNetCore.Identity;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Data;
using System;

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
                _context.Add(categoria);
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
    }
}

