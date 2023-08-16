let mostrador = document.getElementById("mostrador");
let seleccion = document.getElementById("seleccion");
let imgSeleccionada = document.getElementById("img");
let modeloSeleccionado = document.getElementById("modelo");
let descripSeleccionada = document.getElementById("descripcion");
let precioSeleccionado = document.getElementById("precio");

function cargar(item){
    quitarBordes();
    mostrador.style.width = "100%";
    seleccion.style.width = "100%";
    seleccion.style.height = "100%"; // Cambio para pantalla completa en dispositivos móviles
    seleccion.style.opacity = "1";
    item.style.border = "2px solid red";

    imgSeleccionada.src = item.getElementsByTagName("img")[0].src;
    modeloSeleccionado.innerHTML =  item.getElementsByTagName("p")[0].innerHTML;
    descripSeleccionada.innerHTML = "Descripción del modelo ";
    precioSeleccionado.innerHTML =  item.getElementsByTagName("span")[0].innerHTML;
}

function cerrar(){
    mostrador.style.width = "0%";
    seleccion.style.width = "0%";
    seleccion.style.height = "0%"; // Restaurar el valor original
    seleccion.style.opacity = "0";
    quitarBordes();
}

function quitarBordes(){
    var items = document.getElementsByClassName("item");
    for(i=0;i <items.length; i++){
        items[i].style.border = "none";
    }
}

function agregarALaLista() {
    // Obtener información del libro seleccionado
    let modelo = document.getElementById('modelo').textContent;
    let descripcion = document.getElementById('descripcion').textContent;
    let autor = document.getElementById('precio').textContent;
  
    // Crear elemento de lista y agregar información del libro
    let listItem = document.createElement('li');
    listItem.innerHTML = '<strong>' + modelo + '</strong> - ' + descripcion + ' - ' + autor;
  
    // Agregar el libro a la lista en la página "PG6.html"
    let listaLibros = document.getElementById('lista-libros');
    listaLibros.appendChild(listItem);
  
    // Redireccionar a la página "PG6.html" después de agregar el libro
    window.location.href = 'PG6.html';
}

function cerrar() {
  mostrador.style.width = "100%"; // Modificamos el tamaño para restaurar el orden
  seleccion.style.width = "0%";
  seleccion.style.height = "0%";
  seleccion.style.opacity = "0";
  quitarBordes();
}