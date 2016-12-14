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
                    alert("user saved");
                });
            };

            var updateDeleteUser = function () {
                dataService.updateDeleteUser(ko.toJS(user));
                showUsers();
            };

            //var deleteUser = function () {
            //    dataService.deleteUser(ko.toJS(user));
            //    showUsers();

            //};


            return {
                user,
                selectPost,
                showUsers,
                saveUser,
                updateDeleteUser
                //deleteUser
            };
        };
    });