app.service("cityService", function ($http) {
    var $this = this;

    $this.GetCities = function () {
        return $http.get("/City/GetCities");
    }

    $this.GetCityByCityCode = function (cityCode) {
        return $http.get("/City/GetCityByCityCode", { params: { cityCode: cityCode } });
    }

    $this.AddEditCity = function (city) {
        return $http.post("/City/AddEditCity", { city: city });
    }
})