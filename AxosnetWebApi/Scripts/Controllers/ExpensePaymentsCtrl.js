var angularApp = angular.module('axosnetApp', []);
angularApp.controller('expensePaymentsListCtrl', function ($scope, $http) {
    $scope.message = "Lista de gastos registrados";
    $scope.newPaymentExchangeRate = 1;
    $scope.selectedExpense = $scope.backendData.Expenses[0];
    $scope.selectedCurrency = $scope.backendData.Currencies[0];
    //$scope.paymentDate = new Date();
    $scope.search = function () {
        $http({
            method: 'GET',
            url: '../ExpenseInvoicePayment/GetAllExpensePayments',
            params: {}
        })
            .success(function (data, status, headers, config) {
            $scope.payments = data;
        });
    };
    $scope.getSelectedExpense = function (selectedExpense) {
        if ($scope.selectedExpense == undefined)
            return;
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
    $scope.search();
    $scope.getSelectedExpense($scope.selectedExpense);
    $scope.openAddExpensePaymentPopUp = function () {
        $('#expensePaymentPanel').modal("show");
    };
    $scope.addNewPaymentExpense = function () {
        $scope.responseMessage = "";
        var amountToPay = $scope.paymentExchangeRate * $scope.paymentAmount;
        if ($scope.paymentDate == undefined) {
            $scope.responseMessage = "La fecha del pago es obligatoria";
            return;
        }
        if (amountToPay <= 0) {
            $scope.responseMessage = "El pago no puede ser por una cantidad menor o igual a cero: " + ($scope.paymentExchangeRate * $scope.paymentAmount) + " > " + $scope.expenseDetailed.Pending + " " + $scope.expenseDetailed.CurrencyCode;
            return;
        }
        if (amountToPay > $scope.expenseDetailed.Pending) {
            $scope.responseMessage = "No se puede pagar un monto superior al de la factura: " + ($scope.paymentExchangeRate * $scope.paymentAmount) + " > " + $scope.expenseDetailed.Pending + " " + $scope.expenseDetailed.CurrencyCode;
            return;
        }
        $http({
            method: 'POST',
            url: '../ExpenseInvoicePayment/AddExpensePayment',
            data: {
                amount: $scope.paymentAmount,
                expenseID: $scope.selectedExpense.Value,
                comment: $scope.paymentComment,
                creationDate: $scope.paymentDate,
                exchangeRate: $scope.paymentExchangeRate,
                currencyCode: $scope.selectedCurrency,
            }
        })
            .success(function (data, status, headers, config) {
            if (data < 0) {
                switch (data) {
                    case -1:
                        $scope.responseMessage = "Ha ocurrido un error: No se encontró la factura";
                        break;
                    case -2:
                        $scope.responseMessage = "Ha ocurrido un error: La factura ya fue saldada";
                        break;
                    case -3:
                        $scope.responseMessage = "Ha ocurrido un error: El monto a pagar supera al pendiente";
                        break;
                    case -4:
                        $scope.responseMessage = "Ha ocurrido un error: La factura ha sido marcada como pagada";
                        break;
                    default:
                        $scope.responseMessage = "Ha ocurrido un error: La factura ha sido marcada como pagada";
                        break;
                }
            }
            else
                $scope.responseMessage = "Se ha dado de alta el recibo #" + data;
            $scope.search();
        });
    };
});
//# sourceMappingURL=ExpensePaymentsCtrl.js.map