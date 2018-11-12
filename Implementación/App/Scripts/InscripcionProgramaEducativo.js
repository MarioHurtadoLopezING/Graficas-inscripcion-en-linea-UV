$(document).ready(function () {
    document.getElementById('tituloGrafica').innerHTML = "Inscripción en línea general por programa educativo";
    buscarRegistros(window.location.search.substr(1).split("=")[1]);
});
function buscarRegistros(periodoEducativo) {
    document.getElementById("menuRegion").href = "inscripcionRegion.aspx?periodo=" + periodoEducativo;
    document.getElementById("menuAreaAcademica").href = "inscripcionAreaAcademica.aspx?periodo=" + periodoEducativo;
    buscarAreasAcademicas(periodoEducativo);
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    $.ajax({
        type: "POST",
        url: 'InscripcionProgramaEducativo.aspx/getProgramasEducativos',
        data: JSON.stringify({ periodoInscripcion: periodoEducativo}),
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
            alert(error.Message);
        }
    });
}
function AreaAcademica(idAreaAcademica, nombreAreaAcademica) {
    this.idAreaAcademica = idAreaAcademica;
    this.nombreAreaAcademica = nombreAreaAcademica;
}
function buscarAreasAcademicas(periodoEducativo) {
    $.ajax({
        type: "POST",
        url: 'InscripcionProgramaEducativo.aspx/getAreasAcademicas',
        data: JSON.stringify({ periodoInscripcion: periodoEducativo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            cargarComboAreas(JSON.parse(datos), periodoEducativo);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function cargarComboAreas(areasAcademicas, periodoEducativo) {
    var areas = new Array();
    $.each(areasAcademicas, function (i, item) {
        areas.push(new AreaAcademica(i + 1, item["nombreAreaAcademica"]));
    });
    var comboAreasAcademicas = document.getElementById("comboAreasAcademicas");
    $.each(areas, function (i, item) {
        var opcionArea = document.createElement("option");
        var nombreArea = document.createTextNode(item.nombreAreaAcademica);
        opcionArea.appendChild(nombreArea);
        comboAreasAcademicas.appendChild(opcionArea);
    });
    comboAreasAcademicas.onchange = function () {
        buscar(comboAreasAcademicas.value, areas, periodoEducativo);
    }
}
function buscar(area, areas, periodoEducativo) {
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    $.each(areas, function (i, item) {
        if (item.nombreAreaAcademica == area) {
            area = item;
        }
    });
    $.ajax({
        type: "POST",
        url: 'InscripcionProgramaEducativo.aspx/getProgramasEducativosPeriodoYArea',
        data: JSON.stringify({ periodoInscripcion: periodoEducativo, idAreaAcademica: area.idAreaAcademica}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            document.getElementById("tituloGrafica").innerHTML = "Incripción en linea: " + area.nombreAreaAcademica;
            crearTabla(JSON.parse(datos));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}