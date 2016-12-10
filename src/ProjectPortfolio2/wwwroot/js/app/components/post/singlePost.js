define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var post = ko.observable(params.post);

            var goToPosts = function () {
                postman.publish(
                    config.events.changeMenu,
                    config.menuItems.posts);
            }

            self.selectTag = function (tag) {
                dataService.getPostsBySearch(tag.title, function (data) {
                    postman.publish(config.events.selectTag, { data : data });
                });
            }


            return {
                post,
                goToPosts,
                selectTag
            };
        };
    });