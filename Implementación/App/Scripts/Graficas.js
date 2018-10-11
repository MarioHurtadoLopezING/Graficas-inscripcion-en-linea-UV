function graficaBarras(lista) {
    var divGraficas = document.getElementById("graficas");
    var canvasGraficas = document.createElement("canvas");
    divGraficas.appendChild(canvasGraficas);
    canvasGraficas.id = "canvasGraficas";
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    $.each(lista, function (i, item) {
        console.log(item);
        fechas.push(item["fecha"]);
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
    var divGraficas = document.getElementById("graficas");
    var canvasGraficas = document.createElement("canvas");
    divGraficas.appendChild(canvasGraficas);
    canvasGraficas.id = "canvasGraficas";

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
    var divGraficas = document.getElementById("graficas");
    var canvasGraficas = document.createElement("canvas");
    divGraficas.appendChild(canvasGraficas);
    canvasGraficas.id = "canvasGraficas";
    var fechas = [];
    var lugaresSorteados = [];
    var lugaresInscritos = [];
    $.each(lista, function (i, item) {
        console.log(item);
        fechas.push(item["fecha"]);
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