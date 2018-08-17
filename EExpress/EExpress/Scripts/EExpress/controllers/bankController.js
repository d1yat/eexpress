app.controller("bankController", function ($scope, bankService) {

    $scope.m = {};
    $scope.message = "";

    $scope.ddlStatus = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Activate" },
        { value: "N", text: "Deactivate" },
    ];

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getBank = function () {
        var request = bankService.GetBank();

        request.then(function (response) {
            $scope.listBank = response.data;
        });
    }

    $scope.getBankById = function (kdbank) {
        var request = bankService.GetBankById(kdbank);

        request.then(function (response) {
            var bank = response.data;

            $scope.m = {
                kdbank: bank.kdbank,
                nmbank: bank.nmbank,
                statusx: bank.statusx,
                norek: bank.norek
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditBank = function () {

        var bank = {
            kdbank: $scope.m.kdbank,
            nmbank: $scope.m.nmbank,
            statusx: $scope.m.statusx,
            norek: $scope.m.norek,
        };

        var request = bankService.AddEditBank(bank);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getBank();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getBank();
})