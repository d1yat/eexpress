app.service("bankService", function ($http) {
    var $this = this;

    $this.GetBank = function () {
        return $http.get("/Bank/GetBank");
    }

    $this.GetBankById = function (kdbank) {
        return $http.get("/Bank/GetBankById", { params: { kdbank: kdbank } });
    }

    $this.AddEditBank = function (bank) {
        return $http.post("/Bank/AddEditBank", { bank: bank });
    }
})