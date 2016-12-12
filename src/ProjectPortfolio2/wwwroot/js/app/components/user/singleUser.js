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
                // save data on backend
                // ko.toJS extract a js object from obervables 
                // see http://knockoutjs.com/documentation/json-data.html
                dataService.saveUser(ko.toJS(user));
                // return to person list
                showUsers();
                // notify user
            };


            return {
                user,
                selectPost,
                showUsers,
                saveUser
            };
        };
    });