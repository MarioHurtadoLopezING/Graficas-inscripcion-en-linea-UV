$(document).ready(function () {
    document.getElementById('tituloGrafica').innerHTML = "Inscripción en línea general por región";
    buscarRegistrosPeriodo();
    buscarRegistros(window.location.search.substr(1).split("=")[1]);
});
function buscarRegistros(fechaRegistro) { 
    document.getElementById("menuAreaAcademica").href = "inscripcionAreaAcademica.aspx?periodo=" + fechaRegistro;
    document.getElementById("menuProgramaEducativo").href = "InscripcionProgramaEducativo.aspx?periodo=" + fechaRegistro;
    obtenerDias(fechaRegistro);
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getRegionesInscripcion',
        data: JSON.stringify({ periodoInscripcion: fechaRegistro}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
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
function buscarRegistrosPeriodo() {
    $.ajax({
        type: 'POST',
        url: 'inscripcionRegion.aspx/getPeriodosEducativos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
         success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            cargarComboPeriodos(JSON.parse(lista));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function cargarComboPeriodos(listaPeriodos) {
    var comboPeriodos = document.getElementById("comboPeriodos");
    $.each(listaPeriodos, function (i, periodo) {
        var opcionPeriodo = document.createElement("option");
        var periodoInscripcion = document.createTextNode(periodo["fechaRegistro"]);
        opcionPeriodo.appendChild(periodoInscripcion);
        comboPeriodos.appendChild(opcionPeriodo);
    });
    comboPeriodos.onchange = function () {
        var objeto;
        $.each(listaPeriodos, function (i, item) {
            if (comboPeriodos.value === item["fechaRegistro"]) {
                objeto = item;
            }
        });
        buscarRegistros(objeto["valorRegistro"]);
    }
}
function obtenerDias(periodoEducativo) {
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getDiasInscripcion',
        data: JSON.stringify({ periodoEducativo: periodoEducativo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            datos = JSON.parse(JSON.stringify(data));
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            cargarComboDias(JSON.parse(lista), periodoEducativo);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function cargarComboDias(listaDias, periodoEducativo) {
    var comboDias = document.getElementById("comboDiasInscripcion");
    while (comboDias.firstChild) {
        comboDias.removeChild(comboDias.firstChild);
    }
    $.each(listaDias, function (i, dia) {
        var opcionDia = document.createElement("option");
        var periodoInscripcion = document.createTextNode(dia["fechaRegistro"]);
        opcionDia.appendChild(periodoInscripcion);
        comboDias.onchange = function () {
            buscarDatos(comboDias.value, periodoEducativo, listaDias);
        }
        comboDias.appendChild(opcionDia);
    });
}

function buscarDatos(fecha, periodo, listaDias) {
    var objeto;
    $.each(listaDias, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }
    });
    $.ajax({
        type: "POST",
        url: 'inscripcionRegion.aspx/getRegionesInscripcionDia',
        data: JSON.stringify({ fecha: objeto["valorRegistro"], periodoEducativo: periodo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            datos = JSON.parse(JSON.stringify(data));
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            lista = JSON.parse(lista);
            var tabla = document.getElementById("tabla");
            while (tabla.firstChild) {
                tabla.removeChild(tabla.firstChild);
            }
            document.getElementById('tituloGrafica').innerHTML = "Inscripción en línea: " + objeto["fechaRegistro"];
            crearTabla(lista);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}