app.service("siteDomainService", function ($http) {
    var $this = this;

    $this.GetOrigin = function () {
        return $http.get("/SiteDomain/GetOrigin");
    }

    $this.GetSiteDomain = function () {
        return $http.get("/SiteDomain/GetSiteDomain");
    }

    $this.GetOriginBySiteName = function (siteName) {
        return $http.get("/SiteDomain/GetOriginBySiteName", { params: { siteName: siteName } });
    }

    $this.AddEditSiteDomain = function (siteDomain) {
        return $http.post("/SiteDomain/AddEditSiteDomain", { siteDomain: siteDomain });
    }
})