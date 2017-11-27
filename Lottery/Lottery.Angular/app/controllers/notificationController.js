app.controller('notification', ['$scope', 'Hub', function ($scope, Hub) {

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
}])