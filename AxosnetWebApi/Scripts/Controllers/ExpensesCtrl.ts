﻿var angularApp = angular.module('axosnetApp', []);

interface ExpenseListScope extends ng.IScope {
    message: string;
    search();
    //providers: AxosnetWebApi.Models.ProviderVM[];
    responseMessage: string;
    addNewExpense();
    newExpenseConcept: string;
    newExpenseTotal: number;
    newExpenseCurrencyCode: string;
    openAddExpensePopUp();
    backendData: AxosnetWebApi.Models.ExpenseInvoices.ExpenseBackendDataVM;
    selectedProvider: AxosnetWebApi.Models.TextValue;
}

angularApp.controller('expensesListCtrl', function ($scope: ExpenseListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de gastos registrados";

    $scope.selectedProvider = $scope.backendData.Providers[0];

    $scope.openAddExpensePopUp = function () {
        $('#expensePanel').modal("show");
    }

    $scope.addNewExpense = function ()
    {
        $scope.responseMessage = "";

        if (!$scope.newExpenseConcept) {
            $scope.responseMessage = "Se necesita agregar concepto de la factura";
            return;
        }
        if (!$scope.newExpenseTotal) {
            $scope.responseMessage = "Se necesita agregar el monto de la factura";
            return;
        }

        $http({
            method: 'POST',
            url: '../ExpenseInvoices/AddNewExpenseInvoice',
            data: {
                concept: $scope.newExpenseConcept,
                providerID: $scope.selectedProvider.Value,
                amount: $scope.newExpenseTotal,
                currencyCode: $scope.newExpenseCurrencyCode,
            }
        })
            .success(function (data: AxosnetWebApi.Models.ProviderVM[], status, headers, config) {
                $('#providerPanel').modal("hide");
               // $scope.search();

            });
    }

});
