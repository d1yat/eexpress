app.controller("productController", function ($scope, productService) {

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

    $scope.getProducts = function () {
        var request = productService.GetProducts();

        request.then(function (response) {
            $scope.products = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getProductById = function (id) {
        var request = productService.GetProductById(id);

        request.then(function (response) {
            var product = response.data;

            $scope.m = {
                kode: product.kode,
                nm: product.nm,
                statusx: product.statusx,
                id: product.id
            };
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.addEditProduct = function () {
        var product = {
            kode: $scope.m.kode,
            nm: $scope.m.nm,
            statusx: $scope.m.statusx,
            id: $scope.m.id
        };

        var request = productService.AddEditProduct(product);

        request.then(function (response) {
            $scope.getProducts();
            $scope.resetForm();

            $scope.message = response.data;
        }, function (response) {
            $scope.message = response.statusText;
        });
    }

    $scope.getProducts();
});