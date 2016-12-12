define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function () {
        var users = ko.observableArray([]);
        self.userName = ko.observable();
        self.personAge = ko.observable();
        $("#new__user").hide();
        $(".new__user__button").click(function (e) {
            $("#new__user").show();
        });
     
        var selectUser = function (user) {
            dataService.getSingleUser(user.id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }
        var createUser = function (self) {
            dataService.createUser(ko.toJS(self));

        };

        dataService.getUsers(function (data) {
            users(data.users);
        });

        return {
            users,
            selectUser,
            userName,
            personAge,
            createUser
        };
    };
});
