define(['knockout', 'dataservice', 'config', 'postman'], function (ko, dataService, config, postman) {
    return function () {
        var menuItems = [
            { title: config.menuItems.posts, component: 'post-list' }, //Is specified in main.js
            { title: config.menuItems.users, component: 'user-list' },
            { title: config.menuItems.wordCloud, component: 'word-cloud' }
        ];
        var currentComponent = ko.observable();
        var currentParams = ko.observable();
        var selectedMenu = ko.observable();
        var searchQuery = ko.observable();

        var search = function () {
            var searchString = searchQuery();
            dataService.getPostsBySearch(searchString, function (data) {
                postman.publish(config.events.searchPost, { data: data });
            });
        }


        var selectMenu = function (menu) {
            selectedMenu(menu);
            currentComponent(menu.component);
        }

        var isSelected = function (menu) {
            return menu === selectedMenu();
        }

        selectMenu(menuItems[0]);

        postman.subscribe(config.events.selectPost, function (params) {
            currentParams(params);
            currentComponent("single-post");
        });
        postman.subscribe(config.events.selectUser, function (params) {
            currentParams(params);
            currentComponent("single-user");
        });
        postman.subscribe(config.events.createUser, function (params) {
            currentParams(params);
            currentComponent("create-user");
        });

        postman.subscribe(config.events.showUsers, function (params) {
            currentParams(params);
            currentComponent("user-list");
        });
        postman.subscribe(config.events.selectTag, function (params) {
            currentParams(params);
            currentComponent("search-tag");
        });
        postman.subscribe(config.events.searchPost, function (params) {
            currentParams(params);
            currentComponent("search-post");
        });



        return {
            menuItems,
            currentComponent,
            currentParams,
            selectMenu,
            searchQuery,
            search,
            isSelected
        }
    }
});