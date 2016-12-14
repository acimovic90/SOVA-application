define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function (params) {
        var users = ko.observableArray([]);
        var curPage = ko.observable(params ? params.url : undefined);
        var total = ko.observable();
        var prevUrl = ko.observable();
        var nextUrl = ko.observable();

        
        var selectUser = function (user) {
            dataService.getSingleUser(user.id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }

        dataService.getUsers(curPage(), function (data) {
            setData(data);
        });
       


        var canPrev = function () {
            return prevUrl();
        };

        var canNext = function () {
            return nextUrl();
        };

        var showPrev = function () {
            dataService.getUsers(prevUrl(), function (data) {
                setData(data);
            });
        }

        var showNext = function () {
            dataService.getUsers(nextUrl(), function (data) {
                setData(data);
            });
        }
        
        var setData = function (data) {
            users(data.users);
            total(data.total);
            prevUrl(data.prev);
            nextUrl(data.next);
        };


        var createUser = function () {
            postman.publish(config.events.createUser);
        }


        return {
            users,
            selectUser,
            createUser,
            total,
            prevUrl,
            nextUrl,
            canPrev,
            canNext,
            showPrev,
            showNext
        };
    };
});
