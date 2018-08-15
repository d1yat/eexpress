app.controller("siteDomainController", function ($scope, siteDomainService) {

    $scope.m = {};
    $scope.message = "";

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getOrigin = function () {
        var request = siteDomainService.GetOrigin();

        request.then(function (response) {
            $scope.listOrigin = response.data;
        });
    }

    $scope.getSiteDomain = function () {
        var request = siteDomainService.GetSiteDomain();

        request.then(function (response) {
            $scope.listSiteDomain = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.onSelectChange = function () {
        var request = siteDomainService.GetOriginBySiteName($scope.m.nmd);

        request.then(function (response) {
            var origin = response.data;

            $scope.m = {
                my_domain: origin.kdkota,
                nmd: origin.nm
            };
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditSiteDomain = function () {
        var siteDomain = {
            my_domain: $scope.m.my_domain,
            nmd: $scope.m.nmd
        };

        var request = siteDomainService.AddEditSiteDomain(siteDomain);

        request.then(function (response) {
            $scope.resetForm();
            $scope.getOrigin();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getOrigin();
    $scope.getSiteDomain();
})