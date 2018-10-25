$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getPeriodosEducativos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var listaPeriodos = JSON.stringify(data);
            listaPeriodos = JSON.parse(listaPeriodos);
            var PeriodosInscripcion;
            for (clave in listaPeriodos) {
                PeriodosInscripcion = listaPeriodos[clave];
            }
            PeriodosInscripcion = JSON.parse(PeriodosInscripcion);
            cargarComboPeriodos(PeriodosInscripcion);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
});

/*------------------------------------------------------------------------*/
function cargarComboPeriodos(periodosInscripcion) {
    var comboPeriodos = document.getElementById("comboPeriodos");
    $.each(periodosInscripcion, function (i, periodo) {
        var opcionPeriodo = document.createElement("option");
        var periodoInscripcion = document.createTextNode(periodo["fechaRegistro"]);
        console.log(periodo["valorRegistro"]);
        opcionPeriodo.appendChild(periodoInscripcion);
        comboPeriodos.appendChild(opcionPeriodo);
    });
    comboPeriodos.onchange = function () {
        buscarRegistros(comboPeriodos.value, periodosInscripcion);
    }
}
/*------------------------------------------------------------------------*/
function buscarRegistros(fecha, lista) {
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    var objeto;
    $.each(lista, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
        }
    });
    document.getElementById("menuRegion").addEventListener("click", function () {
        document.getElementById("menuRegion").href = "inscripcionRegion.aspx?periodo="+objeto["valorRegistro"];
    });
    document.getElementById("lblPeriodoInscripcion").innerHTML = "Inscripción en línea " + objeto["fechaRegistro"];
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getDiasInscripcion',
        data: JSON.stringify({ fecha: objeto["valorRegistro"] }),
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