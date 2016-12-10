define(['jquery'], function ($) {


    var getPosts = function (callback) {
        var url = "api/posts";
        $.getJSON(url, function (data) {
            callback(data);
        });
    }
    var getPostsBySearch = function (words, callback) {
        debugger;
        var url = "api/posts?searchfor=" + words;
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getSinglePost = function (id, callback) {
        var url = "api/posts/"+id;
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getUsers = function (callback) {
        var url = "api/users";
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    return {
        getPosts,
        getSinglePost,
        getPostsBySearch,
        getUsers
    };
});
