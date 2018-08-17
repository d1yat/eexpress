app.controller("valutaController", function ($scope, valutaService) {

    $scope.m = {};
    $scope.message = "";

    $scope.ddlStatus = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Activate" },
        { value: "N", text: "Deactivate" },
    ];

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getValuta = function () {
        var request = valutaService.GetValuta();

        request.then(function (response) {
            $scope.listValuta = response.data;
        });
    }

    $scope.getValutaById = function (kode) {
        var request = valutaService.GetValutaById(kode);

        request.then(function (response) {
            var valuta = response.data;

            $scope.m = {
                kode: valuta.kode,
                nm: valuta.nm,
                statusx: valuta.statusx,
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditValuta = function () {

        var valuta = {
            kode: $scope.m.kode,
            nm: $scope.m.nm,
            statusx: $scope.m.statusx,
        };

        var request = valutaService.AddEditValuta(valuta);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getValuta();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getValuta();
})