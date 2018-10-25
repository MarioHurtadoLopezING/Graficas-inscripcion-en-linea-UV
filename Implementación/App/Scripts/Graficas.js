
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
    var canvasGraficas = document.getElementById("canvas");
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    $.each(lista, function (i, item) {

        if (item["fecha"]) {
            fechas.push(item["fecha"]);
        } else if (item["nombreRegion"]) {
            fechas.push(item["nombreRegion"]);
        }
        lugaresSorteados.push(item["lugaresSorteados"]);
        lugaresInscritos.push(item["lugaresInscritos"]);
    });
    var datosGrafica = {
        labels: fechas,
        datasets: [
            {
                label: "Lugares sorteados",
                backgroundColor: 'rgba(99, 132, 0, 0.6)',
                borderColor: 'rgba(99, 132, 0, 1)',
                data: lugaresSorteados
            },
            {
                label: "Lugares inscritos",
                backgroundColor: 'rgba(0, 99, 132, 0.6)',
                borderColor: 'rgba(0, 99, 132, 1)',
                data: lugaresInscritos
            }
        ]
    };
    var myBarChart = new Chart(canvasGraficas, {
        type: 'bar',
        data: datosGrafica
        
    });
}
function graficaPastel(lista) {
    var canvasGraficas = document.getElementById("canvas");
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
                "rgba(99, 132, 0, 0.6)",
                "rgba(0, 99, 132, 0.6)",
            ]
        }]  
    };
    var myBarChart = new Chart(canvasGraficas, {
        type: 'pie',
        data: datosGrafica
    });
}
function graficaLineal(lista) {
    var canvasGraficas = document.getElementById("canvas");
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    $.each(lista, function (i, item) {
        if (item["fecha"]) {
            fechas.push(item["fecha"]);
        } else if (item["nombreRegion"]) {
            fechas.push(item["nombreRegion"]);
        }
        lugaresSorteados.push(item["lugaresSorteados"]);
        lugaresInscritos.push(item["lugaresInscritos"]);
    });
    var datosGrafica = {
        labels: fechas,
        datasets: [
            {
                label: "Lugares sorteados",
                backgroundColor: 'rgba(99, 132, 0, 0.6)',
                borderColor: 'rgba(99, 132, 0, 1)',
                data: lugaresSorteados
            },
            {
                label: "Lugares inscritos",
                backgroundColor: 'rgba(0, 99, 132, 0.6)',
                borderColor: 'rgba(0, 99, 132, 1)',
                data: lugaresInscritos
            }
        ]
    };
    var myBarChart = new Chart(canvasGraficas, {
        type: 'line',
        data: datosGrafica
    });
}