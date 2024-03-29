﻿var angularApp = angular.module('axosnetApp', []);

interface ProvidersListScope extends ng.IScope {
    message: string;
    search();
    providers: AxosnetWebApi.Models.ProviderVM[];
    openAddProviderPopUp();
    responseMessage: string;
    addNewProvider();
    newProviderName: string;
    newProviderTelephone: string;
}

angularApp.controller('providersListCtrl', function ($scope: ProvidersListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de proveedores registrados";
    $scope.responseMessage = "";
    $scope.newProviderName = undefined;
    $scope.newProviderTelephone = undefined;
    $scope.search = function () {
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

    $scope.openAddProviderPopUp = function () {
        $('#providerPanel').modal("show");
    }

    $scope.addNewProvider = function () {
        $scope.responseMessage = "";

        if (!$scope.newProviderName) {
            $scope.responseMessage = "Se necesita agregar el nombre del proveedor";
            return;
        }
        if (!$scope.newProviderTelephone) {
            $scope.responseMessage = "Se necesita agregar el num. telefónico del proveedor";
            return;
        }

        $http({
            method: 'POST',
            url: '../Providers/AddNewProvider',
            data: {
                ProviderName: $scope.newProviderName,
                Telephone: $scope.newProviderTelephone,
            }
        })
            .success(function (data: AxosnetWebApi.Models.ProviderVM[], status, headers, config) {
                $('#providerPanel').modal("hide");
                $scope.search();
          
            });

    }

    $scope.search();


});
