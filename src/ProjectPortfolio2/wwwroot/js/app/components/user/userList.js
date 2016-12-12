﻿define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function () {
        $("#new__user").hide();
        $(".new__user__button").click(function (e) {
            $("#new__user").show();
        });

        $(".button__success").click(function (e) {
            $("#new__user").hide();
        });
        var users = ko.observableArray([]);

        var selectUser = function (user) {
            dataService.getSingleUser(user.id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }

        dataService.getUsers(function (data) {
            users(data.users);
        });

        return {
            users,
            selectUser
        };
    };
});
