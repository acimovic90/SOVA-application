define(['jquery'], function ($) {


    var getPosts = function (callback) {
        var url = "api/posts";
        $.getJSON(url, function (data) {
            callback(data);
        });
    }



    return {
        getPosts
    };
});
