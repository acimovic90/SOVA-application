define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function (params) {
        var posts = ko.observableArray([]);

        var selectPost = function (post) {
            dataService.getSinglePost(post.id, function (data) {
                postman.publish(config.events.selectPost, { post: data });
            });
        }

        dataService.getPosts(function (data) {
            posts(data.posts);
        });

        return {
            posts,
            selectPost
        };
    };
});
