(function () {
    this.CostPerSecond = this.CostPerSecond || {};
    var ns = this.CostPerSecond;

    // Crear nuevo costo
    ns.Create = function (type) {
        var d = $.Deferred();

        var cost = $("#cost").val();

        if (!cost) {
            alert("Por favor ingrese la información.");
            return false;
        }

        var _cost = { Id: 1, Cost: cost };

        setTimeout(function () {
            $.ajax({
                type: "POST",
                url: "/api/Parametrization/PostCostPerSecond",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (costResul) {
                    if (costResul) {
                        alert("Costo creado correctamente");
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
                data: JSON.stringify(_cost)

            });

            d.resolve();
        }, 0);

        return d.promise();
    }

}());


$(function () {
    
});