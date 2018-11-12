function crearTabla(lista) {
    var totalSorteado = 0;
    var totalInscrito = 0;
    $.each(lista, function (i, item) {
        totalSorteado = totalSorteado + item["lugaresSorteados"];
        totalInscrito = totalInscrito + item["lugaresInscritos"];
    });
    var tabla = document.getElementById("tabla");
    for (var i = 0; i < lista.length; i++) {
        var objetoJson = lista[i];
        var filaEncabezado = document.createElement("tr");
        for (var clave in objetoJson) {
            var celda = document.createElement("th");
            var texto = document.createTextNode(clave);
            celda.appendChild(texto);
            filaEncabezado.appendChild(celda);
        }
        var celda = document.createElement("th");
        var texto = document.createTextNode("% Total");
        celda.appendChild(texto);
        filaEncabezado.appendChild(celda);
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
        resultado = resultado.toFixed(2)+ " %";
        fila.appendChild(document.createElement("td").appendChild(document.createTextNode(resultado)));
        tabla.appendChild(fila);
    }
    var fila = document.createElement("tr");
    var celda = document.createElement("th");
    var texto = document.createTextNode("Total");
    celda.appendChild(texto);
    fila.appendChild(celda);
    var celda1 = document.createElement("th");
    var texto1 = document.createTextNode(totalSorteado);
    celda1.appendChild(texto1);
    fila.appendChild(celda1);
    var celda2 = document.createElement("th");
    var texto2 = document.createTextNode(totalInscrito);
    celda2.appendChild(texto2);
    fila.appendChild(celda2);
    var total = totalInscrito * 100;
    total = total / totalSorteado;
    total = total.toFixed(2) + " %";
    var celda3 = document.createElement("th");
    var texto3 = document.createTextNode(total);
    celda3.appendChild(texto3);
    fila.appendChild(celda3);
    tabla.appendChild(fila);
    graficaBarras(lista);
}