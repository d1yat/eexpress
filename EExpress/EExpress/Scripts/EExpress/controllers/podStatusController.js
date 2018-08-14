app.controller("podStatusController", function ($scope, podStatusService) {

    $scope.m = {};
    $scope.message = "";

    $scope.ddlStatus = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Activate" },
        { value: "N", text: "Deactivate" }
    ];

    $scope.ddlRelation = [
        { value: "", text: "Please Select" },
        { value: "Y", text: "Success" },
        { value: "C", text: "Reject" }
    ];

    $scope.resetForm = function () {
        $scope.m = {};
    }

    $scope.getPODStatus = function () {
        var request = podStatusService.GetPODStatus();

        request.then(function (response) {
            $scope.listPODStatus = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getPODStatusById = function (id) {
        var request = podStatusService.GetPODStatusById(id);

        request.then(function (response) {
            var podStatus = response.data;

            $scope.m = {
                kode: podStatus.kode,
                nm: podStatus.nm,
                statusx: podStatus.statusx,
                kode_relasi: podStatus.kode_relasi,
                id: podStatus.id
            };
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditPODStatus = function () {
        var podStatus = {
            nm: $scope.m.nm,
            statusx: $scope.m.statusx,
            kode_relasi: $scope.m.kode_relasi,
            id: $scope.m.id
        }

        var request = podStatusService.AddEditPODStatus(podStatus);

        request.then(function (response) {
            $scope.getPODStatus();
            $scope.resetForm();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getPODStatus();
})