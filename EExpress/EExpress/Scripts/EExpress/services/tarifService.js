/// <reference path="../app.js" />

app.service("tarifService", function ($http) {
    var $this = this;

    $this.GetCities = function () {
        return $http.get("/Tarif/GetCities");
    }

    $this.GetCityById = function (kdkota) {
        return $http.get("/Tarif/GetCityById", { params: { kdkota: kdkota } });
    }

    $this.GetShipmentType = function () {
        return $http.get("/Tarif/GetShipmentType");
    }

    $this.GetProduct = function () {
        return $http.get("/Tarif/GetProduct");
    }

    $this.GetTarif = function () {
        return $http.get("/Tarif/GetTarif");
    }

    $this.AddEditTarif = function (tarif) {
        return $http.post("/Tarif/AddEditTarif", { tarif: tarif });
    }
});