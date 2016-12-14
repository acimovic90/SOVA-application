define(['jquery'], function ($) {
    var postsUrl = "api/posts";
    var usersUrl = "api/users";


    var getPosts = function (url, callback) {
        if (url === undefined) {
            url = postsUrl;
        }
        $.getJSON(url, function (data) {
            callback(data);
        });
    }
    var getUsers = function (url, callback) {
        if (url === undefined) {
            url = usersUrl;
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
        var url = "api/users/" + id;
        $.ajax({
            type: 'GET',
            url: url,
            contentType: "application/json"
        }).done(callback);
    }
    var createUser = function (user, callback) {
        var url = "api/users";
        $.ajax({
            type: 'POST',
            url: url,
            contentType: "application/json",
            data: JSON.stringify(user)
        }).done(callback);
    }

    var deleteUser = function (id, callback) {
        $.ajax({
            type: "DELETE",
            url: "api/users/" + id,
            contentType: "application/json",
            data: JSON.stringify(getUsers) // rember that data should be a JSON string
        }).done(callback);
    }

    var saveUser = function (getUsers, callback) {
        $.ajax({
            type: 'PUT',
            url: getUsers.url,
            contentType: "application/json",
            data: JSON.stringify(getUsers) // rember that data should be a JSON string
        }).done(callback);
    };

    //var deleteUser = function (getSingleUser) {
    //    $.ajax({
    //        type: 'DELETE',
    //        url: getSingleUser.url,
    //        contentType: "application/json",
    //        data: JSON.stringify(getSingleUser) // rember that data should be a JSON string
    //    });

    //};
   

    return {
        getPosts,
        getPostsBySearch,
        getWordCloudWords,
        getSinglePost,
        getSingleUser,
        createUser,
        getUsers,
        saveUser,
        deleteUser
    };
});
