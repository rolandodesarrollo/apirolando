var angularApp = angular.module('axosnetApp', []);
angularApp.controller('providersListCtrl', function ($scope, $http) {
    $scope.message = "Lista de proveedores registrados";
    $scope.search = function () {
        $http({
            method: 'GET',
            url: '../Providers/GetAllProviders',
            params: {}
        })
            .success(function (data, status, headers, config) {
            $scope.providers = data;
        });
    };
    $scope.search();
});
//# sourceMappingURL=ProvidersCtrl.js.map