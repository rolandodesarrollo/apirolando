var angularApp = angular.module('axosnetApp', []);
angularApp.controller('expensesListCtrl', function ($scope, $http) {
    $scope.message = "Lista de gastos registrados";
    $scope.selectedProvider = $scope.backendData[0];
    $scope.openAddExpensePopUp = function () {
        $('#expensePanel').modal("show");
    };
    $scope.addNewExpense = function () {
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
            .success(function (data, status, headers, config) {
            $('#providerPanel').modal("hide");
            // $scope.search();
        });
    };
});
//# sourceMappingURL=ExpensesCtrl.js.map