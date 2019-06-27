var angularApp = angular.module('axosnetApp', []);

interface ProvidersListScope extends ng.IScope {
    message: string;
    search();
    providers: AxosnetWebApi.Models.ProviderVM[];
}

angularApp.controller('providersListCtrl', function ($scope: ProvidersListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de proveedores registrados";

    $scope.search = function ()
    {
        $http({
            method: 'GET',
            url: '../Providers/GetAllProviders',
            params: {
            }
        })
            .success(function (data: AxosnetWebApi.Models.ProviderVM[], status, headers, config) {
                $scope.providers = data;

        });


    }

    $scope.search();


});
