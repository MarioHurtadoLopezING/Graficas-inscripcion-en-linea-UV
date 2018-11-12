$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getPeriodosEducativos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            listaPeriodos = JSON.parse(JSON.stringify(data));
            for (clave in listaPeriodos) {
                listaPeriodos = listaPeriodos[clave];
            }
            cargarComboPeriodos(JSON.parse(listaPeriodos));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
});
function cargarComboPeriodos(periodosInscripcion) {
    var comboPeriodos = document.getElementById("comboPeriodos");
    $.each(periodosInscripcion, function (i, periodo) {
        var opcionPeriodo = document.createElement("option");
        var periodoInscripcion = document.createTextNode(periodo["fechaRegistro"]);
        if (periodo["valorRegistro"].indexOf('M') > 0) {
            document.getElementById("menuRegion").href = "inscripcionRegion.aspx?periodo=" + periodo["valorRegistro"];
            document.getElementById("menuAreaAcademica").href = "inscripcionAreaAcademica.aspx?periodo=" + periodo["valorRegistro"];
            document.getElementById("menuProgramaEducativo").href = "InscripcionProgramaEducativo.aspx?periodo=" + periodo["valorRegistro"];
            buscarRegistros(periodo["fechaRegistro"], periodosInscripcion);
        }
        opcionPeriodo.appendChild(periodoInscripcion);
        comboPeriodos.appendChild(opcionPeriodo);
    });
    comboPeriodos.onchange = function () {
        buscarRegistros(comboPeriodos.value, periodosInscripcion);
    }
}
function buscarRegistros(fecha, lista) {
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    var objeto;
    $.each(lista, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            objeto = item;
            document.getElementById("menuRegion").href = "inscripcionRegion.aspx?periodo=" + objeto["valorRegistro"];
            document.getElementById("menuAreaAcademica").href = "inscripcionAreaAcademica.aspx?periodo=" + objeto["valorRegistro"];
            document.getElementById("menuProgramaEducativo").href = "InscripcionProgramaEducativo.aspx?periodo=" + objeto["valorRegistro"];
        }
    });
    var tituloGrafica = document.getElementById("tituloGrafica");
    tituloGrafica.innerHTML = "Inscripción en línea " + objeto["fechaRegistro"];
    $.ajax({
        type: "POST",
        url: 'Default.aspx/getDiasInscripcion',
        data: JSON.stringify({ fecha: objeto["valorRegistro"] }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            crearTabla(JSON.parse(datos));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Messa+ge);
        }
    });
}