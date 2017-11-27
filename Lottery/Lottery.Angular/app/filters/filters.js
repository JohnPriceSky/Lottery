app.filter('parseDate', function () {
    return function (timestamp) {
        var date = timestamp.split('T')[0] + ' ' + timestamp.split('T')[1];
        date = date.slice(0, date.lastIndexOf(':'));
        return date;
    };
});