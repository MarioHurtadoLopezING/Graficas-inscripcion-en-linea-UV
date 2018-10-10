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
function buscarRegistros(fecha, lista) {
    var div = document.getElementById("graficas");
    while (div.firstChild) {
        div.removeChild(div.firstChild);
    }
    console.log(fecha);
    var objeto;
    $.each(lista, function (i, item){
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }
    });
    console.log(objeto);
    console.log(objeto["valorRegistro"]);
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getDiasInscripcion',
        data: JSON.stringify({ fecha: objeto["valorRegistro"]}),
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
    var totalSorteado = 0;
    var totalInscrito = 0;
    $.each(lista, function (i, item) {
        totalSorteado = totalSorteado + item["lugaresSorteados"];
        totalInscrito = totalInscrito + item["lugaresInscritos"];
    });
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
        var texto = document.createTextNode("% Total");
        filaEncabezado.appendChild(document.createElement("th").appendChild(texto));
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
    fila.appendChild(document.createElement("td").appendChild(document.createTextNode("total")));
    fila.appendChild(document.createElement("td").appendChild(document.createTextNode(totalSorteado)));
    fila.appendChild(document.createElement("td").appendChild(document.createTextNode(totalInscrito)));
    var total = totalInscrito * 100;
    total = total / totalSorteado;
    fila.appendChild(document.createElement("td").appendChild(document.createTextNode(total)));

    document.getElementById("graficas").appendChild(tabla);
    document.getElementById("tablasDias").appendChild(fila);
    graficaPastel(lista);
    graficaBarras(lista);
    graficaLineal(lista);
}
