
class Uploadpicture {
    // El parametro "evt" contendra el evento de nuestro input file
    // El parametro "id" contendra la id de un elemento donde nosotros vamos a visualizar la imagen
    archivo(evt,id)
    {
        // Coleccion de objetos
        let files = evt.target.files; //Filelist Object
        //Obtenemos el dato que esta en la posicion cero la cual sera la informacion de nuestro input file
        let f = files[0];
        // Si es un archivo de tipo imagen
        if (f.type.match('image.*')) {
            let reader = new FileReader();
            // El siguiente objeto contiene toda la informacion que esta entre "{}" y vamos a leer toda esa informacion
            reader.onload = ((theFile) => {
                return (e) => {
                    document.getElementById(id).innerHTML = ['<img class="responsive-img ' + id +
                        ' " src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                }
            })(f);
            // Leee la informacion anterior
            reader.readAsDataURL(f);

        }


    }
}
