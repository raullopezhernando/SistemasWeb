// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var categorias = new Categorias();

var curso = new Cursos();

// Funcion anonima
var cursoImage = (evt) => {

    curso.archivo(evt, "cursoImage");
}

// Una funcion que siempre se este ejecutando cada vez que nosotros cargemos la aplicacion o actualicemos una vista 
// o pasemos a alguna seccion o vista

var principal = new Principal();
// Funcion anonima
$().ready(() => {

    // Capturaremos todos los parametros de la URL del navegador y los guardamos en la variable "URLactual"
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
});
