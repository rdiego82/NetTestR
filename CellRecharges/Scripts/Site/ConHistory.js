(function () {
    this.ConHistory = this.ConHistory || {};
    var ns = this.ConHistory;

    // Consultar historial de Recargas
    ns.CurHistory = function (type) {
        var d = $.Deferred();
        setTimeout(function () {
            $.get("/api/ConHist", function (cConsHistory) {
                if (cConsHistory) {
                    var seccion = "<table id='tblConsumo' border='2px'> <tr><td>Línea</td><td>Costo</td><td>Fecha</td></tr>";
                    var selConsumo = $("#Consumo");

                    for (var index = 0; index < cConsHistory.length; index++) {
                        seccion = seccion.concat("<tr><td>" + cConsHistory[index].CellPhoneNumber + "</td> <td>" + cConsHistory[index].Cost + "</td> <td>" + cConsHistory[index].Date + "</td></tr>");
                    }

                    seccion = seccion.concat("</table>");
                    selConsumo.append(seccion);

                    d.resolve(cConsHistory);
                }
                else
                    d.resolve();
            });
        }, 0);

        return d.promise();

    }

}());


$(function () {
    ConHistory.CurHistory();
});