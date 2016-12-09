define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService,postman, config) {
    return function () {
        var users = ko.observableArray([]);

        return {
            users
        };
    };
});
