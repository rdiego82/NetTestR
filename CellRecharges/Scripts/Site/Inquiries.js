(function () {
    this.Inquiry = this.Inquiry || {};
    var ns = this.Inquiry;

    // Consultar saldo actual
    ns.CurBalance = function (type) {
        var d = $.Deferred();
        setTimeout(function () {          
            $.get("/api/inquiries", function (cBalance) {
                if (cBalance) {
                    var selBalance = $("#Saldo");
                    var seccion = "<table id='tblBalance' border='2px'> <tr><td>Línea</td><td>Costo</td><td>Segundos</td></tr>";

                    for (var index = 0; index < cBalance.length; index++) {
                        seccion = seccion.concat("<tr><td>" + cBalance[index].CellPhoneNumber + "</td> <td>" + cBalance[index].Cost + "</td> <td>" + cBalance[index].Seconds + "</td></tr>");
                    }
                    
                    seccion = seccion.concat("</table>");
                    selBalance.append(seccion);
                    
                    d.resolve(cBalance);
                }
                else
                    d.resolve();
            });          
        }, 0);

        return d.promise();
        
    }


   
}());


$(function () {
    Inquiry.CurBalance();
});