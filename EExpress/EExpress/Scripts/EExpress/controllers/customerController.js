app.controller("customerController", function ($scope, customerService) {

    $scope.m = {};
    $scope.message = "";

    getCustomers();

    $scope.getCustomerById = function (id) {
        var request= customerService.GetCustomerById(id);

        request.then(function (response) {
            var customer = response.data;

            $scope.m = {
                custno: customer.custno,
                nm: customer.nm,
                alm1: customer.alm1,
                alm2: customer.alm2,
                alm3: customer.alm3,
                tlp: customer.tlp,
                ct_person: customer.ct_person,
                statusx: customer.statusx,
                ctk_hrg: customer.ctk_hrg,
                npwp: customer.npwp,
                k_payment: customer.k_payment,
                hrgkhs: customer.hrgkhs,
                cetak_penerima: customer.cetak_penerima,
                user_entry: customer.user_entry,
                hrgspecial: customer.hrgspecial,
            };

            $("#btnTermInvoice").removeClass("disabled");
            $("#btnDivisi").removeClass("disabled");

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditCustomer = function () {
        var customer = {
            custno: $scope.m.custno,
            nm: $scope.m.nm,
            alm1: $scope.m.alm1,
            alm2: $scope.m.alm2,
            alm3: $scope.m.alm3,
            tlp: $scope.m.tlp,
            ct_person: $scope.m.ct_person,
            statusx: $scope.m.statusx,
            ctk_hrg: $scope.m.ctk_hrg,
            npwp: $scope.m.npwp,
            k_payment: $scope.m.k_payment,
            hrgkhs: $scope.m.hrgkhs,
            cetak_penerima: $scope.m.cetak_penerima,
            user_entry: "ADMIN", //$scope.m.user_entry,
            hrgspecial: $scope.m.hrgspecial,
        };

        var request = customerService.AddEditCustomer(customer);
        showMessage(request);
        $scope.resetForm();
    }

    $scope.ddlStatus = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Activate" },
        { value: "N", text: "Deactivate" }
    ];

    $scope.ddlYesNo = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Ya" },
        { value: "N", text: "Tidak" }
    ];

    $scope.ddlPaymentMethod = [
        { value: "", text: "Please Select" },
        { value: "CSH", text: "Cash" },
        { value: "KRD", text: "Credit" }
    ];

    function getCustomers() {
        var request= customerService.GetCustomers();

        request.then(function (response) {
            $scope.customers = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    function showMessage(request) {
        request.then(function successCallback(response) {
            getCustomers();

            $scope.message = response.data;
        }, function errorCallback(response) {
            $scope.message = response.statusText;
        });
    }

    $scope.resetForm = function() {
        $scope.m = {};

        $("#btnTermInvoice").addClass("disabled");
        $("#btnDivisi").addClass("disabled");
    }
});