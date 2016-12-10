define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var post = ko.observable(params.post);

            var goToPosts = function () {
                postman.publish(
                    config.events.changeMenu,
                    config.menuItems.posts);
            }

            return {
                post,
                goToPosts
            };
        };
    });