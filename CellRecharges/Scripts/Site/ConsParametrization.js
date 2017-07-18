(function () {
    this.ConsParametrization = this.ConsParametrization || {};
    var ns = this.ConsParametrization;

    // Consultar historial de Recargas
    ns.CurParametrization = function (type) {
        var d = $.Deferred();
        setTimeout(function () {
            $.get("/api/Parametrization", function (cConsParam) {
                if (cConsParam) {
                    var seccion = "<table id='tblParametrizacion' border='2px'> <tr><td>Costo</td><td>Fecha</td></tr>";
                    var selParam = $("#Parametrizacion");

                    for (var index = 0; index < cConsParam.length; index++) {
                        seccion = seccion.concat("<tr><td>" + cConsParam[index].Cost + "</td> <td>" + cConsParam[index].Date + "</td></tr>");
                    }

                    seccion = seccion.concat("</table>");
                    selParam.append(seccion);

                    d.resolve(cConsParam);
                }
                else
                    d.resolve();
            });
        }, 0);

        return d.promise();

    }

}());


$(function () {
    ConsParametrization.CurParametrization();
});