app.controller("courierController", function ($scope, courierService) {

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

    $scope.getCourier = function () {
        var request = courierService.GetCourier();

        request.then(function (response) {
            $scope.listCourier = response.data;
        });
    }

    $scope.getCourierById = function (id) {
        var request = courierService.GetCourierById(id);

        request.then(function (response) {
            var courier = response.data;

            $scope.m = {
                kode: courier.kode,
                nm: courier.nm,
                statusx: courier.statusx,
                tlp: courier.tlp,
                jns_kendaraan: courier.jns_kendaraan,
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditCourier = function () {
        var courier = {
            kode: $scope.m.kode,
            nm: $scope.m.nm,
            statusx: $scope.m.statusx,
            tlp: $scope.m.tlp,
            jns_kendaraan: $scope.m.jns_kendaraan,
        };

        var request = courierService.AddEditCourier(courier);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getCourier();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getCourier();
})