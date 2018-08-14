app.service("productService", function ($http) {
    var $this = this;

    $this.GetProducts = function () {
        return $http.get("/Product/GetProducts");
    }

    $this.GetProductById = function (id) {
        return $http.get("/Product/GetProductById", { params: { id: id } });
    }

    $this.AddEditProduct = function (product) {
        return $http.post("/Product/AddEditProduct", { product: product });
    }
})