app.service("valutaService", function ($http) {
    var $this = this;

    $this.GetValuta = function () {
        return $http.get("/Valuta/GetValuta");
    }

    $this.GetValutaById = function (kode) {
        return $http.get("/Valuta/GetValutaById", { params: { kode: kode } });
    }

    $this.AddEditValuta = function (valuta) {
        return $http.post("/Valuta/AddEditValuta", { valuta: valuta });
    }
})