app.filter('parseDate', function () {
    return function (timestamp) {
        var date = timestamp.split('T')[0] + ' ' + timestamp.split('T')[1];
        return date;
    };
});