using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Areas.Cursos.Models;

namespace SistemasWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Los DbSet son necesarios para integrar nuestros modelos en las tablas
        // Si no los metemos no podren crear las tablas ya que no habra un modelo con el que crearlas
        // Para crear tablas comando "add-migration nombre de migracion"

        public DbSet<TCategoria> _TCategoria { get; set; }
        public DbSet<TCursos> _TCursos { get; set; }

    }
}
