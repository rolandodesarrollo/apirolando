var angularApp = angular.module('axosnetApp', []);

interface ProvidersListScope extends ng.IScope {
    message: string;
}

angularApp.controller('providersListCtrl', function ($scope: ProvidersListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de proveedores registrados";


});
