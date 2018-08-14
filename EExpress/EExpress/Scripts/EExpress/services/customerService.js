app.service("customerService", function ($http) {
    var $this = this;

    //$this.GetCustomers = function () {
    //    return $http.get("/Customer/GetCustomers");
    //}

    $this.GetCustomers = function (pageIndex, pageSize) {
        return $http.get("/Customer/GetCustomers", {
            params: { pageIndex: pageIndex, pageSize: pageSize }
        });
    }

    $this.GetCustomerById = function (id) {
        return $http.get("/Customer/GetCustomerById", { params: { id: id } });
    }

    $this.AddEditCustomer = function (customer) {
        return $http.post("/Customer/AddEditCustomer", { customer: customer });
    }

    $this.GetTermInvoice = function (id) {
        return $http.get("/Customer/GetTermInvoice", { params: { id: id } });
    }

    $this.AddEditTermInvoice = function (termInvoice) {
        return $http.post("/Customer/AddEditTermInvoice", { termInvoice: termInvoice });
    }

    $this.GetDivisi = function (cust_id) {
        return $http.get("/Customer/GetDivisi", { params: { customerId: cust_id } });
    }

    $this.GetDivisiById = function (id) {
        return $http.get("/Customer/GetDivisiById", { params: { id: id } });
    }

    $this.AddEditDivisi = function (divisi) {
        return $http.post("/Customer/AddEditDivisi", { divisi: divisi });
    }
});
