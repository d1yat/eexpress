app.service("courierService", function ($http) {
    var $this = this;

    $this.GetCourier = function () {
        return $http.get("/Courier/GetCourier");
    }

    $this.GetCourierById = function (id) {
        return $http.get("/Courier/GetCourierById", { params: { id: id } });
    }

    $this.AddEditCourier = function (courier) {
        return $http.post("/Courier/AddEditCourier", { courier: courier });
    }
})