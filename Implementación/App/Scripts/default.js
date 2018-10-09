$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getPeriodosEducativos',
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
            crearCombo(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
});
function crearCombo(lista) {
    var comboFechas = document.createElement("select");
    $.each(lista, function (i, item) {
        var opcion = document.createElement("option");
        var fecha = document.createTextNode(item["fechaRegistro"]);
        opcion.appendChild(fecha);
        comboFechas.onchange = function () {
            buscarRegistros(comboFechas.value,lista);
        }
        comboFechas.appendChild(opcion);
    });
    document.getElementById("combos").appendChild(comboFechas);
}
function buscarRegistros(fecha,lista) {
    console.log(fecha);
    var objeto;
    $.each(lista, function (i, item){
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }
    });
    console.log(objeto);
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getDiasInscripcion',
        data: JSON.stringify({ fecha:"201901"}),
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
            crearTabla(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function crearTabla(lista){
    console.log(lista);
    var tabla = document.createElement("table");
    tabla.id = "tablasDias";
    for (var i = 0; i < lista.length; i++) {
        var objetoJson = lista[i];
        var filaEncabezado = document.createElement("tr");
        for (var clave in objetoJson) {
            var celda = document.createElement("th");
            var texto = document.createTextNode(clave);
            celda.appendChild(texto);
            filaEncabezado.appendChild(celda);
        }
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
        tabla.appendChild(fila);
    }

    document.getElementById("combos").appendChild(tabla);
}
