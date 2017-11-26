app.controller('admin', ['$scope', '$http', '$location', function ($scope, $http, $location) {
    $scope.username = userName;
    $scope.lotteries = {};

    getLotteries();

    $scope.removeLottery = function (id) {

        $http.post(host + '/deleteLottery', id).then(function (response) {

            getLotteries();

        }, function (err) { });
    };

    $scope.addLottery = function () {

        $http.post(host + '/addLottery', {
            lotteryName: $scope.lotteryName,
            prize: $scope.prize,
            drowTime: $scope.drowTime
        }).then(function (response) {

            getLotteries();

        }, function (err) { });

        $scope.lotteryName = '';
        $scope.prize = '';
        $scope.drowTime = '';
    };

    function getLotteries() {

        $http.get(host + '/lotteries').then(function (response) {
            $scope.lotteries = response.data;
        }, function () { });
    }
}]);