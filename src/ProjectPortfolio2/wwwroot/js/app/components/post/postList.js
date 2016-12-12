define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function (params) {
        var posts = ko.observableArray([]);

        var selectPost = function (post) { //Indside postListView.html
            dataService.getSinglePost(post.id, function (data) {
                postman.publish(config.events.selectPost, { post: data });
            });
        }

        if (params !== undefined && params.data !== undefined && params.data.posts.length !== 0) {
            posts(params.data.posts);
        } else {
            dataService.getPosts(function (params) {
                posts(params.posts);
            });

        }



        return {
            posts,
            selectPost

        };
    };
});
