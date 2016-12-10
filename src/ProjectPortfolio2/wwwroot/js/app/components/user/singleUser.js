define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var user = ko.observable(params.user);


            self.selectPost = function (post) {
                dataService.getSinglePost(post.id, function (data) {
                    postman.publish(config.events.selectPost, { post: data });
                });
            }


            return {
                user,
                selectPost
            };
        };
    });