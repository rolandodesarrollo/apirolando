var angularApp = angular.module('axosnetApp', []);
angularApp.controller('expensePaymentsListCtrl', function ($scope, $http) {
    $scope.message = "Lista de gastos registrados";
    $scope.newPaymentExchangeRate = 1;
    $scope.selectedExpense = $scope.backendData.Expenses[0];
    $scope.selectedCurrency = $scope.backendData.Currencies[0];
    $scope.getSelectedExpense = function (selectedExpense) {
        $http({
            method: 'GET',
            url: '../ExpenseInvoices/GetExpenseInvoiceByID',
            params: {
                expenseID: $scope.selectedExpense.Value
            }
        })
            .success(function (data, status, headers, config) {
            $scope.expenseDetailed = data;
            $scope.selectedCurrency = $scope.backendData.Currencies[0];
            $scope.paymentExchangeRate = data.ExchangeRate;
            $scope.paymentAmount = data.Pending * data.ExchangeRate;
        });
    };
    $scope.changeAmountByCurrency = function (selectedCurrency) {
        if (selectedCurrency != 'MXN')
            $scope.paymentAmount = $scope.expenseDetailed.Pending;
        else
            $scope.paymentAmount = $scope.expenseDetailed.Pending * $scope.expenseDetailed.ExchangeRate;
    };
    $scope.getSelectedExpense($scope.selectedExpense);
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
    };
    $scope.addNewPaymentExpense = function () {
        $scope.responseMessage = "";
        if (($scope.paymentExchangeRate * $scope.paymentAmount) > $scope.expenseDetailed.Pending) {
            $scope.responseMessage = "No se puede pagar un monto superior al de la factura: " + ($scope.paymentExchangeRate * $scope.paymentAmount) + " > " + $scope.expenseDetailed.Pending + " " + $scope.expenseDetailed.CurrencyCode;
            return;
        }
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
    };
});
