
class Categorias {

    RegistrarCategoria() {
        $.post(
            "GetCategorias",
            $('.formCategoria').serialize(),
            (response) => {
                try {
                    var item = JSON.parse(response);
                    if (item.Code == "Done") {
                        window.location.href = "Categoria";
                    } else {
                        document.getElementById("mensaje").innerHTML = item.Description;
                    }
                } catch (e) {
                    document.getElementById("mensaje").innerHTML = response;
                }

                console.log(response);
            }
        );
    }
    EditCategoria(data)
    {
        document.getElementById("catNombre").value = data.Nombre;
        document.getElementById("catDescripcion").value = data.Descripcion;

        // Observamos que con estado en checked y no value. Esto es porque la propiedad
        // estado es checkeable mediante un checkbox (booleano, no campo de texto).

        document.getElementById("catEstado").checked = data.Estado;

        document.getElementById("catCategoriaID").value = data.CategoriaID;
        console.log(data);
    }
}

