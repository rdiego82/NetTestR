(function () {
    this.Process = this.Process || {};
    var ns = this.Process;

    // Crear carga y consumo en dinero
    ns.CreateProcess = function (type) {
        var d = $.Deferred();

        var cel = $("#celNumber").val();
        var cost = $("#cost").val();

        if (!cel || !cost)
        {
            alert("Por favor ingrese la información.");
            return false;
        }

        var _process = { Id: 1, CellPhoneNumber: cel, Cost: cost, Type: type };
            
        setTimeout(function () {
            $.ajax({
                type: "POST",
                url: "/api/Process/PostProcess",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (confResul) {
                    if (confResul) {
                        if(type === 'R')
                            alert("Carga realizada al celular: " + cel);
                        else
                            alert("Consumo actualizado para el celular: " + cel);
                        $("#celNumber").val("");
                        $("#cost").val("");
                        d.resolve();
                    }
                    else {
                        alert("Error al realizar la recarga. Por favor verifique.");
                        d.reject();
                    }

                },
                error: function (request, status, error) {
                    if (request.responseText.includes("recarga"))
                        alert("El valor del consumo excede el valor de la recarga. Por favor verificar");

                    d.reject();
                },
                data: JSON.stringify(_process)
                
            });

            d.resolve();
        }, 0);
        return d.promise();
    }

    
}());

$(function () {
});