define(['jquery'], function ($) {
    var postsUrl = "api/posts";

    var getPosts = function (url, callback) {
        if (url === undefined) {
            url = postsUrl;
        }
        $.getJSON(url, function (data) {
            callback(data);
        });
    }
    var getPostsBySearch = function (words, callback) {      
        var url = "api/posts?searchfor=" + words;
        $.getJSON(url, function (data) {
            callback(data);
        });
    }
    var getWordCloudWords = function (words, callback) {
        var url = "api/posts/wordcloud?searchfor=" + words;
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
    var getSingleUser = function (id, callback) {
        var url = "api/users/"+id;
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
        getPostsBySearch,
        getWordCloudWords,
        getSinglePost,
        getSingleUser,
        getUsers
    };
});
