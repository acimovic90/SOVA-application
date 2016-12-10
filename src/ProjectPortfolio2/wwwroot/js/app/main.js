(function (undefined) {

    require.config({
        baseUrl: "js", 
        paths: {
            "jquery": "lib/jquery/dist/jquery.min",
            "knockout": "lib/knockout/dist/knockout",
            "text": "lib/requirejs-text/text",
            "tether": "lib/tether/dist/js/tether.min",
            "bootstrap": "lib/bootstrap/dist/js/bootstrap.min",
            //"toastr": "lib/toastr/toastr.min",

            "dataservice": "app/services/dataService",
            "postman": "app/services/postman",
            "config": "app/config"
        },
        shim: {    
            "bootstrap": { "deps": ['jquery'] }
        }
    });

    require(['knockout'], function (ko) {
        ko.components.register("my-app", {
            viewModel: { require: 'app/components/app/app' },
            template: { require: 'text!app/components/app/appView.html' }
        });

        ko.components.register("post-list", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });
        ko.components.register("search-tag", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });

        ko.components.register("single-post", {
            viewModel: { require: 'app/components/post/singlePost' },
            template: { require: 'text!app/components/post/singlePostView.html' }
        });
   

        ko.components.register("user-list", {
            viewModel: { require: 'app/components/user/userList' },
            template: { require: 'text!app/components/user/userListView.html' }
        });

    });
    require(['tether'], function (Tether) {
        window.Tether = Tether;
    });
        
    require(['knockout', 'bootstrap'], function (ko) {
        ko.applyBindings();
    });

})();