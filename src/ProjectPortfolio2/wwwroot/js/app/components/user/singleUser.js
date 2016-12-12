define(['knockout', 'dataservice', 'jquery', 'postman', 'config'],
    function (ko, dataService, $, postman, config) {
        return function (params) {
            $("#update__profile").hide();
            $(".update__profile__button").click(function (e) {
                $("#update__profile").show();
            });
            var user = ko.observable(params.user);
            self.selectPost = function (post) {
                dataService.getSinglePost(post.id, function (data) {
                    postman.publish(config.events.selectPost, { post: data });
                });
            }

            var showUsers = function () {
                postman.publish(
                    config.events.changeMenu,
                    { title: config.menuItems.users, params });
            };
 
            var saveUser = function () {
                dataService.saveUser(ko.toJS(user));
                showUsers();

            };

            var deleteUser = function () {
                dataService.deleteUser(ko.toJS(user));
                showUsers();

            };


            return {
                user,
                selectPost,
                showUsers,
                saveUser,
                deleteUser
            };
        };
    });