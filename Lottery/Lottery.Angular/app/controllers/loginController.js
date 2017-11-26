app.controller('login', ['$scope', '$http', '$location', function ($scope, $http, $location) {

    $scope.loginIn = function () {

        $http.post(host + '/login', {
            userName: $scope.username,
            password: $scope.password
        }).then(function (response) {

            if (response.data.IsLoggedIn) {

                userId = response.data.Id;
                userName = $scope.username;

                $location.path('/dashboard');
            }
            else {
                alert('Wrong username or password!');
            }
        }, function (err) { });
    };

    $scope.loginAsAdmin = function () {

        $http.post(host + '/loginToAdmin', {
            userName: $scope.username,
            password: $scope.password
        }).then(function (response) {

            if (response.data) {

                userName = $scope.username;

                $location.path('/admin');
            }
            else {
                alert('Wrong username or password!');
            }
        }, function (err) { });
    };

    $scope.register = function () {

        $http.post(host + '/register', {
            userName: $scope.username,
            password: $scope.password
        }).then(function (response) {

            if (response.data) {
                alert('Account has been created!');
            }
            else {
                alert('You already have a account!');
            }
        }, function (err) { });
    };
}]);