app.controller('dashboard', ['$scope', '$http', '$location', 'Hub', function ($scope, $http, $location, Hub) {
    $scope.username = userName;
    $scope.lotteries = {};

    var notificationHub = new Hub('notificationHub', {
        rootPath: host + '/signalr',
        jsonp: true,
        listeners: {
            'notification': function (message) {
                alert(message);
            }
        },
        methods: ['notification']
    });

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