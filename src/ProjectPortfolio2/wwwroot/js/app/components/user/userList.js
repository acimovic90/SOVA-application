define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function () {
        var users = ko.observableArray([]);

        var selectUser = function (user) {
            dataService.getSingleUser(user.id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }

        var createUser = function () {
            postman.publish(config.events.createUser);
        }

        dataService.getUsers(function (data) {
            users(data.users);
        });

        return {
            users,
            selectUser,
            createUser
        };
    };
});
