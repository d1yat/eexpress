app.controller("signatureController", function ($scope, signatureService) {

    $scope.m = {};
    $scope.message = "";

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getSignature = function () {
        var request = signatureService.GetSignature();

        request.then(function (response) {
            $scope.listSignature = response.data;

        });
    }

    $scope.getSignatureDetails = function () {
        var request = signatureService.GetSignatureDetails();

        request.then(function (response) {
            var signature = response.data;

            $scope.m = {
                my_domain: signature.DomainCode,
                nmsignpjk: signature.Tax,
                nmpjbt: signature.Finance,
                paymentx: signature.PaymentDescription,
                bnk: signature.BankAccDescription
            };

        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditSignature = function () {
        var signature = {
            DomainCode: $scope.m.my_domain,
            Tax: $scope.m.nmsignpjk,
            Finance: $scope.m.nmpjbt,
            PaymentDescription: $scope.m.paymentx,
            BankAccDescription: $scope.m.bnk
        };

        var request = signatureService.AddEditSignature(signature);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getSignature();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getSignature();
})