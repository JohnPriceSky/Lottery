app.controller('dashboard', ['$scope', '$http', '$location', 'parseDateFilter', function ($scope, $http, $location) {
    $scope.username = userName;
    $scope.lotteries = {};

    getLotteries();

    $scope.showDetails = function (id) {

        lotteryId = id;

        $location.path('/lottery');
    };

    function getLotteries() {

        $http.get(host + '/lotteries').then(function (response) {
            $scope.lotteries = response.data;
        }, function () { });
    }
}]);