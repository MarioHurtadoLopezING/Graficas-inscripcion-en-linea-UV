var listaRegionesGeneral;

function Region(idRegion, nombreRegion) {
    this.idRegion = idRegion;
    this.nombreRegion = nombreRegion;
}
$(document).ready(function () {
    buscarRegistros(window.location.search.substr(1).split("=")[1]);
    buscarRegistrosPeriodo();
});
function buscarRegistros(periodoEducativo) {
    document.getElementById("menuRegion").href = "inscripcionRegion.aspx?periodo=" + periodoEducativo;
    document.getElementById("menuProgramaEducativo").href = "InscripcionProgramaEducativo.aspx?periodo=" + periodoEducativo;
    document.getElementById('tituloGrafica').innerHTML = "Inscripción en línea general por área académica";
    obtenerDias(periodoEducativo);
    buscarRegiones(periodoEducativo);
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    $.ajax({
        type: "POST",
        url: 'inscripcionAreaAcademica.aspx/getAreasAcademicas',
        data: JSON.stringify({ periodoInscripcion: periodoEducativo}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var areasAcademicas = JSON.parse(JSON.stringify(data));
            for (key in areasAcademicas) {
                areasAcademicas = areasAcademicas[key];
            }
            crearTabla(JSON.parse(areasAcademicas)); 
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}
function buscarRegiones(periodoInscripcion) {
    $.ajax({
        type: "POST",
        url: 'inscripcionAreaAcademica.aspx/getRegiones',
        data: JSON.stringify({ periodoInscripcion: periodoInscripcion }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            var lista;
            for (key in datos) {
                lista = datos[key];
            }
            cargarComboRegiones(JSON.parse(lista), periodoInscripcion);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });  
}
function cargarComboRegiones(listaRegiones, periodoInscripcion) {
    var regiones = new Array();
    $.each(listaRegiones, function (i, item) {
        regiones.push(new Region(i + 1, item["nombreRegion"]));
    });
    listaRegionesGeneral = regiones;
    var comboRegiones = document.getElementById("comboRegiones");
    while (comboRegiones.firstChild) {
        comboRegiones.removeChild(comboRegiones.firstChild);
    }
    $.each(regiones, function (i, item) {
        var opcionRegion = document.createElement("option");
        var nombreRegion = document.createTextNode(item.nombreRegion);
        opcionRegion.appendChild(nombreRegion);
        comboRegiones.appendChild(opcionRegion);
    });
    comboRegiones.onchange = function () {
        buscar(comboRegiones.value, regiones, periodoInscripcion);
    }
}
function buscar(region, regiones, periodoInscripcion) {
    var tabla = document.getElementById("tabla");
    while (tabla.firstChild) {
        tabla.removeChild(tabla.firstChild);
    }
    $.each(regiones, function (i, item) {
        if (item.nombreRegion == region) {
            region = item;
        }
    });
    $.ajax({
        type: "POST",
        url: 'inscripcionAreaAcademica.aspx/getAreasAcademicasPorRegion',
        data: JSON.stringify({ periodoInscripcion: periodoInscripcion, idRegion: region.idRegion}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            document.getElementById("tituloGrafica").innerHTML = "Incripción en linea: " + region.nombreRegion;
            crearTabla(JSON.parse(datos));
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
        url: 'inscripcionAreaAcademica.aspx/getPeriodosEducativos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            cargarComboPeriodos(JSON.parse(datos));
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
        $.each(listaPeriodos, function (i, item) {
            if (comboPeriodos.value === item["fechaRegistro"]) {
                buscarRegistros(item["valorRegistro"]);
            }
        }); 
    }
}
function obtenerDias(periodoEducativo) {
    $.ajax({
        type: "POST",
        url: 'inscripcionAreaAcademica.aspx/getDiasInscripcion',
        data: JSON.stringify({ periodoEducativo: periodoEducativo }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            cargarComboDias(JSON.parse(datos), periodoEducativo,);
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
            buscarDatos(comboDias.value, periodoEducativo, listaDias, document.getElementById("comboRegiones").value);
        }
        comboDias.appendChild(opcionDia);
    });
}
function buscarDatos(fecha, periodo, listaDias, regionCombo) {
    var region;
    $.each(listaRegionesGeneral, function (i, item) {
        if (regionCombo === item["nombreRegion"]) {
            region = item;
        }
    });
    var dia;
    $.each(listaDias, function (i, item) {
        if (fecha === item["fechaRegistro"]) {
            dia = item;
        }
    });
     $.ajax({
        type: "POST",
        url: 'inscripcionAreaAcademica.aspx/getAreasAcademicasPorRegionYFecha',
        data: JSON.stringify({ periodoInscripcion: periodo, fecha: dia["valorRegistro"], idRegion: region.idRegion}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            var datos = JSON.parse(JSON.stringify(data));
            for (key in datos) {
                datos = datos[key];
            }
            var tabla = document.getElementById("tabla");
            while (tabla.firstChild) {
                tabla.removeChild(tabla.firstChild);
            }
            document.getElementById('tituloGrafica').innerHTML = "Inscripción en línea al: " + dia["fechaRegistro"];
            crearTabla(JSON.parse(datos));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var error = eval("(" + XMLHttpRequest.responseText + ")");
            alert(error.Message);
        }
    });
}