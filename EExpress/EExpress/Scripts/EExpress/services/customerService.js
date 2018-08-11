app.service("customerService", function ($http) {
    var $this = this;

    $this.GetCustomers = function () {
        return $http.get("/Customer/GetCustomers");
    }

    $this.GetCustomerById = function (id) {
        return $http.get("/Customer/GetCustomerById", { params: { id: id } });
    }

    $this.AddEditCustomer = function (customer) {
        return $http.post("/Customer/AddEditCustomer", { customer: customer });
    }
});
