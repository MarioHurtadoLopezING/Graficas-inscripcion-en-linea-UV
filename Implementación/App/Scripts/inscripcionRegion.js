$(document).ready(function () {
    buscarRegistros();
});
function buscarRegistros() {
    var lista = window.location.search.substr(1);
    var parametro = lista.split("=")[1];
    console.log(parametro);
    obtenerDias(parametro);
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getRegionesInscripcion',
        data: JSON.stringify({ periodoInscripcion: parametro}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.stringify(data);
            datos = JSON.parse(datos);
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            lista = JSON.parse(lista);
            console.log(lista);
            crearTabla(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}//getDiasInscripcion
function obtenerDias(periodoEducativo) {
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getDiasInscripcion',
        data: JSON.stringify({ periodoEducativo: periodoEducativo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.stringify(data);
            datos = JSON.parse(datos);
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            lista = JSON.parse(lista);
            console.log(lista);
            cargarComboDias(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function cargarComboDias(listaDias) {
    var comboDias = document.getElementById("comboDiasInscripcion");
    $.each(listaDias, function (i, dia) {
        var opcionDia = document.createElement("option");
        var periodoInscripcion = document.createTextNode(dia["fechaRegistro"]);
        console.log(dia["valorRegistro"]);
        opcionDia.appendChild(periodoInscripcion);
        comboDias.onchange = function () {
            var lista = window.location.search.substr(1);
            buscarDatos(comboDias.value, lista.split("=")[1], listaDias);
        }
        comboDias.appendChild(opcionDia);
    });
}
/**............................*/
function buscarDatos(fecha, periodo, listaDias) {
    alert(fecha + " " + periodo);
    var objeto;
    $.each(listaDias, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }//getRegionesInscripcionDia(String fecha, String periodoEducativo)
    });
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getRegionesInscripcionDia',
        data: JSON.stringify({ fecha: objeto["valorRegistro"], periodoEducativo: periodo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.stringify(data);
            datos = JSON.parse(datos);
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            lista = JSON.parse(lista);
            console.log(lista);
            crearTabla(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });

}
/*----------------------------*/
function crearTabla(lista) {
    console.log(lista);
    var totalSorteado = 0;
    var totalInscrito = 0;
    $.each(lista, function (i, item) {
        totalSorteado = totalSorteado + item["lugaresSorteados"];
        totalInscrito = totalInscrito + item["lugaresInscritos"];
    });
    var tabla = document.getElementById("tabla");
    for (var i = 0; i < lista.length; i++) {
        var objetoJson = lista[i];
        var filaEncabezado = document.createElement("tr");
        for (var clave in objetoJson) {
            var celda = document.createElement("th");
            var texto = document.createTextNode(clave);
            celda.appendChild(texto);
            filaEncabezado.appendChild(celda);
        }
        var celda = document.createElement("th");
        var texto = document.createTextNode("% Total");
        celda.appendChild(texto);
        filaEncabezado.appendChild(celda);
        tabla.appendChild(filaEncabezado);
        break;
    }
    for (var i = 0; i < lista.length; i++) {
        var objeto = lista[i];
        var fila = document.createElement("tr");
        for (var clave in objeto) {
            var celda = document.createElement("td");
            var texto = document.createTextNode(objeto[clave]);
            celda.appendChild(texto);
            fila.appendChild(celda);
        }
        var resultado = objeto["lugaresInscritos"] * 100;
        resultado = resultado / objeto["lugaresSorteados"];
        fila.appendChild(document.createElement("td").appendChild(document.createTextNode(resultado)));
        tabla.appendChild(fila);
    }
    var fila = document.createElement("tr");
    var celda = document.createElement("td");
    var texto = document.createTextNode("Total");
    celda.appendChild(texto);
    fila.appendChild(celda);

    var celda1 = document.createElement("td");
    var texto1 = document.createTextNode(totalSorteado);
    celda1.appendChild(texto1);
    fila.appendChild(celda1);

    var celda2 = document.createElement("td");
    var texto2 = document.createTextNode(totalInscrito);
    celda2.appendChild(texto2);
    fila.appendChild(celda2);

    var total = totalInscrito * 100;
    total = total / totalSorteado;
    var celda3 = document.createElement("td");
    var texto3 = document.createTextNode(total);
    celda3.appendChild(texto3);
    fila.appendChild(celda3);

    tabla.appendChild(fila);
    graficaBarras(lista);

}