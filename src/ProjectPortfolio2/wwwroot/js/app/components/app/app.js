define(['knockout', 'config'], function (ko, config) {
    return function () {
        var menuItems = [
            { title: config.menuItems.posts, component: 'post-list' }, //post-list is specified in main.js
            { title: config.menuItems.users, component: 'user-list' }
            //,
            //{ title: config.menuItems.singlePost, component: 'singlePost' }
        ];
        var currentComponent = ko.observable();
        var selectedMenu = ko.observable();

        var selectMenu = function (menu) {
            selectedMenu(menu);
            currentComponent(menu.component);
        }

        var isSelected = function (menu) {
            return menu === selectedMenu();
        }


        selectMenu(menuItems[0]); //0 for post-list

        return {
            menuItems,
            currentComponent,
            selectMenu,
            isSelected
        }
    }
});