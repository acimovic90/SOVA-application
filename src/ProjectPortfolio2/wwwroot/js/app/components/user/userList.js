define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService,postman, config) {
    return function () {
        var users = ko.observableArray([]);

        console.log(dataService);

        dataService.getUsers(function (data) {
            users(data.users);
        });

        return {
            users
        };
    };
});
