
class Cursos extends Uploadpicture {

    RegistrarCurso() {
        // Coleccion de datos (objetos). Se invoca a FormData
        // Se coloca "Input" y luego el nombre de una propiedad "Input.Nombre". Esto es asi porque la informacion
        // que vamos a enviar al servidor lo va a capturar la clase DataPaginador y en la clase DataPaginador
        // tenemos una propiedad llamada "Input" propiedad que le pertenece a la clase "TCursos"
        // La forma de obtener los datos es JQUERY pero tambien se podria haber utilizado Javascript
        // Ejemplo
        //data.append('Input.Descripcion', document.getElementById("curNombre").value);

        var data = new FormData();
        data.append('Input.Nombre', $("#curNombre").val());
        data.append('Input.Descripcion', $("#curDescripcion").val());
        data.append('Input.Horas', $("#curHoras").val());
        data.append('Input.Costo', $("#curCosto").val());
        data.append('Input.Estado', $("#curEstado").checked);
        data.append('Input.CategoriaID', $("curCatargoria").val());

        // Un each es como un "foreach en JQuery"

        $.each($('input[type=file]')[0].files, (i, file) => {
            data.append('AvatarImage', file);
        });


        class Cursos extends Uploadpicture {

            RegistrarCurso() {
                var data = new FormData();
                data.append('Input.Nombre', $("#curNombre").val());
                data.append('Input.Descripcion', $("#curDescripcion").val());
                data.append('Input.Horas', $("#curHoras").val());
                data.append('Input.Costo', $("#curCosto").val());
                data.append('Input.Estado', document.getElementById("curEstado").checked);
                data.append('Input.CategoriaID', $("#curCatargoria").val());
                $.each($('input[type=file]')[0].files, (i, file) => {
                    data.append('AvatarImage', file);
                });
                $.ajax({
                    url: "GetCurso",
                    data: data, // La informacion que vamos a enviar por Post
                    cache: false,
                    contentType: false, // Como se va a enviar una imagen se deshabilita esta opcion
                    processData: false, // Como se va a enviar una imagen se deshabilita esta opcion
                    type: 'POST',
                    // Esta funcion anonima obtendra el resultado que nos envie el servidor
                    success: (result) => {
                        try {
                            // Convertimos el string a una coleccion de objetos
                            var item = JSON.parse(result);
                            if (item.Code == "Done") {
                                // Enviamos por la url el nombre del controlador "Cursos" para poder cargar denuevo la vista
                                window.location.href = "Cursos";
                            } else {
                                document.getElementById("mensaje").innerHTML = item.Description;
                            }


                        } catch (e)
                        {
                            document.getElementById("mensaje").innerHTML = item.Description;

                        }
                        console.log(result);
                    }
                });
            }
        }

    }
    EditCurso(curso, cat)
    {

        console.log(curso);
        console.log(cat);

    }
}
