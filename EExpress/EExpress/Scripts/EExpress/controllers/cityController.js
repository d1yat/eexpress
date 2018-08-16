app.controller("cityController", function ($scope, cityService) {

    $scope.m = {};
    $scope.message = "";

    $scope.ddlStatus = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Activate" },
        { value: "N", text: "Deactivate" },
    ];

    $scope.optionKeyPreview = [
        { value: "Y", text: "Key - Preview (Manifest)" }
    ];

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getCities = function () {
        var request = cityService.GetCities();

        request.then(function (response) {
            $scope.listCity = response.data;
        });
    }

    $scope.getCityByCityCode = function (cityCode) {
        var request = cityService.GetCityByCityCode(cityCode);

        request.then(function (response) {
            var city = response.data;

            $scope.m = {
                original: city.original,
                group_area: city.group_area,
                kdkota: city.kdkota,
                kd_pengiriman: city.kd_pengiriman,
                nm: city.nm,
                alk_manifest: city.alk_manifest,
                statusx: city.statusx,
                keyidx: city.keyidx,
                ambilreport: city.ambilreport,
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditCity = function () {
        //I think this enough for now
        var keyId = $("#keyPreview").is(":checked") ? "Y" : "N";

        var city = {
            original: $scope.m.original,
            group_area: $scope.m.group_area,
            kdkota: $scope.m.kdkota,
            kd_pengiriman: $scope.m.kd_pengiriman,
            nm: $scope.m.nm,
            alk_manifest: $scope.m.alk_manifest,
            statusx: $scope.m.statusx,
            keyidx: keyId,
            ambilreport: $scope.m.ambilreport,
        };

        var request = cityService.AddEditCity(city);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getCities();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getCities();
})