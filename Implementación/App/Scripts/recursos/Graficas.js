function graficaBarras(lista) {
    document.getElementById("pastel").addEventListener("click", function () {
        graficaPastel(lista);
    });
    document.getElementById("barra").addEventListener("click", function () {
        graficaBarras(lista);
    });
    document.getElementById("linea").addEventListener("click", function () {
        graficaLineal(lista);
    });
    var divGrafica = document.getElementById("divGrafica");
    while (divGrafica.firstChild) {
        divGrafica.removeChild(divGrafica.firstChild);
    }
    var canvasGraficas = document.createElement("canvas");
    divGrafica.appendChild(canvasGraficas);
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    var tipoGrafica = 'bar';
    $.each(lista, function (i, item) {
        if (item["fecha"]) {
            fechas.push(item["fecha"]);
        } else if (item["nombreRegion"]) {
            fechas.push(item["nombreRegion"]);
        } else if (item["nombreAreaAcademica"]) {
            fechas.push(item["nombreAreaAcademica"]);
            tipoGrafica = 'horizontalBar';
        } else if (item["nombreProgramaEducativo"]) {
            fechas.push(item["nombreProgramaEducativo"]);
            tipoGrafica = 'horizontalBar';
            canvasGraficas.setAttribute("height","900%");
        }
        lugaresSorteados.push(item["lugaresSorteados"]);
        lugaresInscritos.push(item["lugaresInscritos"]);
    });
    var datosGrafica = {
        labels: fechas,
        datasets: [
            {
                label: "Lugares sorteados",
                backgroundColor: 'rgb(59, 104, 159)',
                borderColor: 'rgb(59, 104, 159)',
                data: lugaresSorteados
            },
            {
                label: "Lugares inscritos",
                backgroundColor: 'rgb(15, 139, 36)',
                borderColor: 'rgb(15, 139, 36)',
                data: lugaresInscritos
            }
        ]
    };
    var myBarChart = new Chart(canvasGraficas.getContext("2d"), {
        type: tipoGrafica,
        data: datosGrafica
    });
}
function graficaPastel(lista) {
    var divGrafica = document.getElementById("divGrafica");
    while (divGrafica.firstChild) {
        divGrafica.removeChild(divGrafica.firstChild);
    }
    var canvasGraficas = document.createElement("canvas");
    divGrafica.appendChild(canvasGraficas);
    var totalSorteado = 0;
    var totalInscrito = 0;
    $.each(lista, function (i, item) {
        totalSorteado = totalSorteado + item["lugaresSorteados"];
        totalInscrito = totalInscrito + item["lugaresInscritos"];
    });
    var datosGrafica = {
        labels: ["Total sorteados","Total inscritos"],
        datasets: [{
            data: [totalSorteado, totalInscrito],
            backgroundColor: [
                'rgb(59, 104, 159)',
                 'rgb(15, 139, 36)',
            ]
        }]  
    };
    var myBarChart = new Chart(canvasGraficas, {
        type: 'pie',
        data: datosGrafica
    });
}
function graficaLineal(lista) {
    var divGrafica = document.getElementById("divGrafica");
    while (divGrafica.firstChild) {
        divGrafica.removeChild(divGrafica.firstChild);
    }
    var canvasGraficas = document.createElement("canvas");
    divGrafica.appendChild(canvasGraficas);
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    var tipoGrafica = 'line';
    $.each(lista, function (i, item) {
        if (item["fecha"]) {
            fechas.push(item["fecha"]);
        } else if (item["nombreRegion"]) {
            fechas.push(item["nombreRegion"]);
        }
        else if (item["nombreAreaAcademica"]) {
            fechas.push(item["nombreAreaAcademica"]);
            tipoGrafica = 'line';
        }
        lugaresSorteados.push(item["lugaresSorteados"]);
        lugaresInscritos.push(item["lugaresInscritos"]);
    });
    var datosGrafica = {
        labels: fechas,
        datasets: [
            {
                label: "Lugares sorteados",
                borderColor: 'rgba(0, 99, 132, 1)',
                backgroundColor: 'transparent',
                data: lugaresSorteados,
            },
            {
                label: "Lugares inscritos",
                borderColor: 'rgba(99, 132, 0, 1)',
                backgroundColor: 'transparent',
                data: lugaresInscritos,
                
            }
        ]
    };
    var myBarChart = new Chart(canvasGraficas, {
        type: tipoGrafica,
        data: datosGrafica,
        options:{
            elements: {
                line: {
                    tension: 0,
                }
            }
        }
    });
}