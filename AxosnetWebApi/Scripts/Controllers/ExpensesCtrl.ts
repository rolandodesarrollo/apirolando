var angularApp = angular.module('axosnetApp', []);

interface ExpenseListScope extends ng.IScope {
    message: string;
    search();
    //providers: AxosnetWebApi.Models.ProviderVM[];
    openAddProviderPopUp();
    responseMessage: string;
    addNewProvider();
    newProviderName: string;
    newProviderTelephone: string;
}

angularApp.controller('expensesListCtrl', function ($scope: ProvidersListScope, $http: ng.IHttpService) {
    $scope.message = "Lista de gastos registrados";
   


});
