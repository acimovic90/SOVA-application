define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function (params) {
        var posts = ko.observableArray([]);
        var total = ko.observable();
        var prevUrl = ko.observable();
        var nextUrl = ko.observable();
        var curPage = ko.observable(params ? params.url : undefined);

        var selectPost = function (post) { //Indside postListView.html
            dataService.getSinglePost(post.id, function (data) {
                postman.publish(config.events.selectPost, { post: data });
            });
        }

        if (params !== undefined && params.data !== undefined && params.data.posts.length !== 0) {
            posts(params.data.posts);
        } else {
            dataService.getPosts(curPage(), function (data) {
                setData(data);
            });
        }

 
        var canPrev = function () {
            return prevUrl();
        };

        var canNext = function () {
            return nextUrl();
        };

        var showPrev = function () {
            dataService.getPosts(prevUrl(), function (data) {
                setData(data);
            });
        }

        var showNext = function () {
            dataService.getPosts(nextUrl(), function (data) {
                setData(data);
            });
        }

        var setData = function (data) {
            posts(data.posts);
            total(data.total);
            prevUrl(data.prev);
            nextUrl(data.next);
        };

        return {
            posts,
            selectPost,
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
