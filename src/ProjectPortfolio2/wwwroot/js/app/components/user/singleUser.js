define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
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
                dataService.saveUser(ko.toJS(user), function () {
                    $('#updated-user-message').removeClass("hidden");
                    setTimeout(function () { $('#updated-user-message').addClass("hidden"); }, 3000);
                });
            };

            var deleteUser = function () {
                dataService.deleteUser(user().id, function () {
                    $('#single-user-container').html('<div class="col-md-3"></div><div class="col-md-6 alert alert-success text-center">The user has been deleted</div>');
                    setTimeout(function () {
                        postman.publish(config.events.showUsers);
                    }, 3000);
                });
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