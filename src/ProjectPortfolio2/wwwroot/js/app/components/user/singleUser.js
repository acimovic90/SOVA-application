define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var user = ko.observable(params.user);

            //var goToPosts = function () {
            //    postman.publish(
            //        config.events.changeMenu,
            //        config.menuItems.posts);
            //}

            //self.selectTag = function (tag) {
            //    debugger;
            //    dataService.getPostsBySearch(tag.title, function (data) {
            //        postman.publish(config.events.selectTag, { data: data });
            //    });
            //}


            return {
                user
            };
        };
    });