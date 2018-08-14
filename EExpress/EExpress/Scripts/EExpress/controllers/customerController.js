app.controller("customerController", function ($scope, customerService) {

    $scope.maxSize = 5;
    $scope.pageIndex = 1;
    $scope.pageSize = 2;
    $scope.totalCount = 0;
    $scope.numberOfPages = [];
    
    $scope.m = {};
    $scope.m.sub = {};
    $scope.m.subdiv = {};
    $scope.message = "";

    getCustomers();

    $scope.getCustomerById = function (id) {
        var request= customerService.GetCustomerById(id);

        request.then(function (response) {
            var customer = response.data;

            $scope.m = {
                id: customer.id,
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
            id: $scope.m.id,
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

    $scope.resetForm = function () {
        $scope.m = {};

        $("#btnTermInvoice").addClass("disabled");
        $("#btnDivisi").addClass("disabled");
    }

    $scope.resetSubdiv = function () {
        $scope.m.subdiv = {};
    }

    $scope.getTermInvoice = function () {
        var request = customerService.GetTermInvoice($scope.m.id);

        request.then(function (response) {
            var termInvoice = response.data;

            $scope.m.sub = {
                cust_id: termInvoice.cust_id,
                nm: termInvoice.nm,
                termx: termInvoice.termx,
                descx: termInvoice.descx
            };
        });
    }

    $scope.addEditTermInvoice = function () {
        var termInvoice = {
            cust_id: $scope.m.sub.cust_id,
            nm: $scope.m.sub.nm,
            termx: $scope.m.sub.termx,
            descx: $scope.m.sub.descx
        }

        var request = customerService.AddEditTermInvoice(termInvoice);
        showMessage(request);

        $("#termInvoice").modal("hide");
        //$scope.resetForm();
    }

    $scope.pageChanged = function () {
        getCustomers();
    }

    $scope.getDivisi = function () {
        var request = customerService.GetDivisi($scope.m.id);

        request.then(function (response) {
            $scope.listDivisi = response.data;

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getDivisiById = function (id) {
        var request = customerService.GetDivisiById(id);

        request.then(function (response) {
            var divisi = response.data;

            $scope.m.subdiv = {
                id: divisi.id,
                nm: divisi.nm,
                alm1: divisi.alm1,
                alm2: divisi.alm2,
                tlp: divisi.tlp,
                ct_person: divisi.ct_person,
                statusx: divisi.statusx,
                ctk_hrg: divisi.ctk_hrg,
                npwp: divisi.npwp,
                k_payment: divisi.k_payment,
                countx: divisi.countx,
                user_entry: divisi.user_entry,
                cust_id: divisi.cust_id
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditDivisi = function () {
        var divisi = {
            id: $scope.m.subdiv.id,
            nm: $scope.m.subdiv.nm,
            alm1: $scope.m.subdiv.alm1,
            alm2: $scope.m.subdiv.alm2,
            tlp: $scope.m.subdiv.tlp,
            ct_person: $scope.m.subdiv.ct_person,
            statusx: $scope.m.subdiv.statusx,
            ctk_hrg: $scope.m.subdiv.ctk_hrg,
            npwp: $scope.m.subdiv.npwp,
            k_payment: $scope.m.subdiv.k_payment,
            countx: 0,
            user_entry: "ADMIN",
            cust_id: $scope.m.id
        }

        var request = customerService.AddEditDivisi(divisi);

        request.then(function (response) {
            //What next?
            $scope.getDivisi($scope.m.id);
        });

        //Clear form of `Divisi / Seksi'
        $scope.resetSubdiv();
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

    $scope.ddlPeriode = [
        { value: "", text: "Please Select" },
        { value: "Hari", text: "Hari" },
        { value: "Bulan", text: "Bulan" },
        { value: "Tahun", text: "Tahun" },
    ]

    function getCustomers() {
        var request= customerService.GetCustomers($scope.pageIndex, $scope.pageSize);

        request.then(function (response) {
            $scope.customers = response.data.IndexViewModel;
            $scope.totalCount = response.data.TotalCount;

            for (var i = 1; i <= $scope.totalCount; i++) {
                $scope.numberOfPages.push(i);
            }
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

});