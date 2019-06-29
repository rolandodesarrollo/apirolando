var angularApp = angular.module('axosnetApp', []);


interface ExpensePaymentsListScope extends ng.IScope {
    message: string;
    search();
    //expenses: AxosnetWebApi.Models.ExpenseInvoices.ExpenseInvoiceVM[];
    responseMessage: string;
    addNewPaymentExpense();
    newPaymentExchangeRate: number;
    backendData: AxosnetWebApi.Models.ExpenseInvoicePayments.ExpensePaymentsBackendDataVM;
    selectedExpense: AxosnetWebApi.Models.TextValue;
    selectedCurrency: string;
    openAddExpensePaymentPopUp();
    getSelectedExpense(selectedExpense: any);
   
}

angularApp.controller('expensePaymentsListCtrl', function ($scope: ExpensePaymentsListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de gastos registrados";
    $scope.newPaymentExchangeRate = 1;
    $scope.selectedExpense = $scope.backendData.Expenses[0];
    $scope.selectedCurrency = $scope.backendData.Currencies[0];

    $scope.getSelectedExpense = function (selectedExpense: any)
    {
        alert(selectedExpense.Value);
    }

    //$scope.search = function () {
    //    $http({
    //        method: 'GET',
    //        url: '../ExpenseInvoices/GetAllExpenseInvoices',
    //        params: {
    //        }
    //    })
    //        .success(function (data: AxosnetWebApi.Models.ExpenseInvoices.ExpenseInvoiceVM[], status, headers, config) {
    //            $scope.expenses = data;


    //        });


    //}

    //$scope.search();

    $scope.openAddExpensePaymentPopUp = function () {
        $('#expensePaymentPanel').modal("show");
    }

    $scope.addNewPaymentExpense = function () {
        $scope.responseMessage = "";
        alert($scope.selectedExpense.Value);

        //if (!$scope.newExpenseConcept) {
        //    $scope.responseMessage = "Se necesita agregar concepto de la factura";
        //    return;
        //}
        //if (!$scope.newExpenseTotal) {
        //    $scope.responseMessage = "Se necesita agregar el monto de la factura";
        //    return;
        //}

        //$http({
        //    method: 'POST',
        //    url: '../ExpenseInvoices/AddNewExpenseInvoice',
        //    data: {
        //        concept: $scope.newExpenseConcept,
        //        providerID: $scope.selectedProvider.Value,
        //        amount: $scope.newExpenseTotal,
        //        currencyCode: $scope.selectedCurrency,
        //        exchangeRate: $scope.newExpenseExchangeRate,
        //    }
        //})
        //    .success(function (data: AxosnetWebApi.Models.ProviderVM[], status, headers, config) {
        //        $('#expensePanel').modal("hide");
        //        $scope.newExpenseConcept = undefined;
        //        $scope.newExpenseCurrencyCode = 'MXN';
        //        $scope.newExpenseTotal = undefined;
        //        $scope.selectedProvider = $scope.backendData.Providers[0];
        //        $scope.search();

        //    });
    }

});

