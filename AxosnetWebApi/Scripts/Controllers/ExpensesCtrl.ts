var angularApp = angular.module('axosnetApp', []);

interface ExpenseListScope extends ng.IScope {
    message: string;
    search();
    //providers: AxosnetWebApi.Models.ProviderVM[];
    responseMessage: string;
    addNewExpense();
    newExpenseConcept: string;
    newExpenseTotal: number;
    newExpenseCurrencyCode: string;
    newExpenseExchangeRate: number;
    openAddExpensePopUp();
    backendData: AxosnetWebApi.Models.ExpenseInvoices.ExpenseBackendDataVM;
    selectedProvider: AxosnetWebApi.Models.TextValue;
    selectedCurrency: string;
}

angularApp.controller('expensesListCtrl', function ($scope: ExpenseListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de gastos registrados";
    $scope.newExpenseExchangeRate = 1;
    $scope.selectedProvider = $scope.backendData.Providers[0];
    $scope.selectedCurrency = $scope.backendData.Currencies[0];

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
                currencyCode: $scope.selectedCurrency,
                exchangeRate: $scope.newExpenseExchangeRate,
            }
        })
            .success(function (data: AxosnetWebApi.Models.ProviderVM[], status, headers, config) {
                $('#expensePanel').modal("hide");
                $scope.newExpenseConcept = undefined;
                $scope.newExpenseCurrencyCode = 'MXN';
                $scope.newExpenseTotal = undefined;
                $scope.selectedProvider = $scope.backendData.Providers[0];
               // $scope.search();

            });
    }

});
