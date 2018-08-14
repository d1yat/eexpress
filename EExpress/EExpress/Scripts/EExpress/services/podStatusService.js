app.service("podStatusService", function ($http) {
    var $this = this;

    $this.GetPODStatus = function () {
        return $http.get("/PODStatus/GetPODStatus");
    }

    $this.GetPODStatusById = function (id) {
        return $http.get("/PODStatus/GetPODStatusById", { params: { id: id } });
    }

    $this.AddEditPODStatus = function (podStatus) {
        return $http.post("/PODStatus/AddEditPODStatus", { podStatus: podStatus });
    }
})