using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Library
{
    public class Uploadimage
    {
        // Hay que pasar la imagen y tener en cuenta el host de donde viene la imagen para cogerla y pasarla
        // a bytes para almacenarla
        public async Task<byte[]> ByteAvatarImageAsync(IFormFile AvatarImage, IWebHostEnvironment environment)
        {
            if (AvatarImage != null)
            {
                // Objeto para almacenar en memoria la imagen
                using (var memoryStream = new MemoryStream())
                {
                    // Copiamos nuestra imagen al objeto "memoryStream"
                    await AvatarImage.CopyToAsync(memoryStream);
                    // El objeto que contiene la imagen lo pasaremos a un array de tipo byte
                    return memoryStream.ToArray();
                }
            }
            else
            {
                // Si no hay imagen disponible pondremos esta imagen por defecto
                var archivoOrigen = environment.ContentRootPath + "/wwwroot/Images/logo-google.png";
                // Este metodo lee y pasa a array de tipo bytes
                return File.ReadAllBytes(archivoOrigen);
            }
        }
    }
}
