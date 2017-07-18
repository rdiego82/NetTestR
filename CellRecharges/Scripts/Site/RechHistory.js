(function () {
    this.RHistory = this.RHistory || {};
    var ns = this.RHistory;

    // Consultar historial de Recargas
    ns.CurHistory = function (type) {
        var d = $.Deferred();
        setTimeout(function () {
            $.get("/api/RechHistory", function (cRechHistory) {
                if (cRechHistory) {
                    var seccion = "<table id='tblRHistory' border='2px'> <tr><td>Línea</td><td>Costo</td><td>Fecha</td></tr>";
                    var selRHistory = $("#Recargas");
                    
                    for (var index = 0; index < cRechHistory.length; index++) {
                        seccion = seccion.concat("<tr><td>" + cRechHistory[index].CellPhoneNumber + "</td> <td>" + cRechHistory[index].Cost + "</td> <td>" + cRechHistory[index].Date + "</td></tr>");
                    }

                    seccion = seccion.concat("</table>");
                    selRHistory.append(seccion);

                    d.resolve(cRechHistory);
                }
                else
                    d.resolve();
            });
        }, 0);

        return d.promise();

    }

}());


$(function () {
    RHistory.CurHistory();
});