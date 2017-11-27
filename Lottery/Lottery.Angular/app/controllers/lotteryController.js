app.controller('lottery', ['$scope', '$http', '$location', 'parseDateFilter', function ($scope, $http, $location) {
    $scope.username = userName;
    $scope.lotteryDetails = {};

    getLotteryDetails();

    $scope.signUp = function (id) {

        $http.post(host + '/signIn', { 
            userId: userId,
            lotteryId: id
        }).then(function (response) {
            if (response.data) {
                getLotteryDetails();
            }
            else {
                alert('You are already in!');
            }
        })
    };

    function getLotteryDetails() {
        $http.get(host + '/lottery?lotteryId=' + lotteryId).then(function (response) {
            $scope.lotteryDetails = response.data;
        });
    }
}]);