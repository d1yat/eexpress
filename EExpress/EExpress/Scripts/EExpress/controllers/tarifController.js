/// <reference path="../services/tarifService.js" />

app.controller("tarifController", function ($scope, tarifService) {

    $scope.m = {};
    $scope.message = "";

    $scope.ddlShipment = [
        { value: "C", text: "Intra kota" },
        { value: "D", text: "Domestic" },
        { value: "I", text: "International" }
    ];

    $scope.ddlCategory = [
        { value: "PBS", text: "Regular" },
        { value: "KHS", text: "Khusus" }
    ];

    $scope.ddlCurrency = [
        { value: "IDR", text: "Rupiah" },
        { value: "USD", text: "Dollar" }
    ];

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getCities = function () {
        var request = tarifService.GetCities();

        request.then(function (response) {
            $scope.listCity = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getShipmentType = function () {
        var request = tarifService.GetShipmentType();

        request.then(function (response) {
            $scope.listShipmentType = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getProduct = function () {
        var request = tarifService.GetProduct();

        request.then(function (response) {
            $scope.listProduct = response.data;
        });
    }

    $scope.getTarif = function () {
        var request = tarifService.GetTarif();

        request.then(function (response) {
            $scope.listTarif = response.data;
        });
    }

    $scope.onCityChange = function () {
        var request = tarifService.GetCityById($scope.m.dst);

        request.then(function (response) {
            var city = response.data;

            $scope.m = {
                kdpengiriman: city.kd_pengiriman
            };
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditTarif = function () {
        var tarif = {
            custno: $scope.m.custno,
            kdproduct: $scope.m.kdproduct,
            dst: $scope.m.dst,
            kdpengiriman: $scope.m.kdpengiriman,
            discnt: $scope.m.discnt,
            kilo1: $scope.m.kilo1,
            kategory: $scope.m.kategory,
            jns_shipment: $scope.m.jns_shipment,
            prckilo1: $scope.m.prckilo1,
            prckilo2: $scope.m.prckilo2,
            valuta_kurs: $scope.m.valuta_kurs,
            ctk_hrg: $scope.m.ctk_hrg,
            kilo_min: $scope.m.kilo_min,
            xtake: $scope.m.xtake,
            xlangsam: $scope.m.xlangsam,
            xnoflat: $scope.m.xnoflat
        };

        var request = tarifService.AddEditTarif(tarif);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getTarif();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getCities();
    $scope.getShipmentType();
    $scope.getProduct();
    $scope.getTarif();
});
