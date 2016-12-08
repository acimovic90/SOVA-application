define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function () {
            var singlePost = ko.observableArray([]);
            debugger;
            var goToPosts = function () {
                postman.publish(
                    config.events.changeMenu,
                    config.menuItems.posts);
            }

            dataService.getSinglePost(function (data) {
                singlePost(data);
            });

            return {
                petssinglePost,
                goToPosts
            };
        };
    });