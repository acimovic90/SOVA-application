﻿(function (undefined) {

    require.config({
        baseUrl: "js", 
        paths: {
            "jquery": "lib/jquery/dist/jquery.min",
            "knockout": "lib/knockout/dist/knockout",
            "text": "lib/requirejs-text/text",
            "tether": "lib/tether/dist/js/tether.min",
            "bootstrap": "lib/bootstrap/dist/js/bootstrap.min",
            "jqcloud2": "lib/jqcloud2/dist/jqcloud.min",

            "dataservice": "app/services/dataService",
            "postman": "app/services/postman",
            "config": "app/config"
        },
        shim: {    
            "bootstrap": { "deps": ['jquery'] }
        }
    });

    require(['knockout'], function (ko) { //Knockout gets passed in the parameter
        ko.components.register("my-app", {
            viewModel: { require: 'app/components/app/app' },
            template: { require: 'text!app/components/app/appView.html' }
        });

        ko.components.register("post-list", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });

        ko.components.register("word-cloud", {
            viewModel: { require: 'app/components/wordCloud/wordCloud' },
            template: { require: 'text!app/components/wordCloud/wordCloudView.html' }
        });
        ko.components.register("search-tag", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });

        ko.components.register("search-post", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });

        ko.components.register("single-post", {
            viewModel: { require: 'app/components/post/singlePost' },
            template: { require: 'text!app/components/post/singlePostView.html' }
        });

        ko.components.register("single-user", {
            viewModel: { require: 'app/components/user/singleUser' },
            template: { require: 'text!app/components/user/singleUserView.html' }
        });
   
        ko.components.register("user-list", {
            viewModel: { require: 'app/components/user/userList' },
            template: { require: 'text!app/components/user/userListView.html' }
        });

    });
    require(['tether'], function (Tether) {
        window.Tether = Tether;
    });
        
    require(['knockout', 'bootstrap', 'jqcloud2'], function (ko) {
        ko.applyBindings();
    });

})();