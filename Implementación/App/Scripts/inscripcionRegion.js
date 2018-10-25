$(document).ready(function () {
    buscarRegistros();
});
function buscarRegistros() {
    var lista = window.location.search.substr(1);
    var parametro = lista.split("=")[1];
    console.log(parametro);
    obtenerDias(parametro);
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
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
    var objeto;
    $.each(listaDias, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }//getRegionesInscripcionDia(String fecha, String periodoEducativo)
    });
    document.getElementById("menuArea").addEventListener("click", function () {
        alert();
        document.getElementById("menuArea").href = "inscripcionArea.aspx";
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
            var tabla = document.getElementById("tabla");
            while (tabla.firstChild) {
                tabla.removeChild(tabla.firstChild);
            }
            crearTabla(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
/*----------------------------*/