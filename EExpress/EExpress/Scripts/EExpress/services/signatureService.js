app.service("signatureService", function ($http) {
    var $this = this;

    $this.GetSignature = function () {
        return $http.get("/Signature/GetSignature");
    }

    $this.GetSignatureDetails = function () {
        return $http.get("/Signature/GetSignatureDetails");
    }

    $this.AddEditSignature = function (signature) {
        return $http.post("/Signature/AddEditSignature", { signature: signature });
    }
})