﻿define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function () {
        var displayname = ko.observable();
        var age = ko.observable();
        var location = ko.observable(); 

        var createUser = function () {
            dataService.createUser({ Displayname: displayname(), Age: age(), Location: location() }, function () {
                alert();
            });

            //postman.publish(config.events.showUsers);
        }

        return {
            displayname,
            age,
            location,
            createUser
        };
    };
});
