define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService,postman, config) {
    return function () {
        var users = ko.observableArray([]);

        var selectUser = function (user) {
            dataService.getSingleUser(user.id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }

        console.log(dataService);

        dataService.getUsers(function (data) {
            users(data.users);
        });

        return {
            users,
            selectUser
        };
    };
});
