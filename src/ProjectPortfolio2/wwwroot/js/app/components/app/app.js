define(['knockout', 'config'], function (ko, config) {
    return function () {
        var menuItems = [
            { title: config.menuItems.persons, component: 'person-list' },
            { title: config.menuItems.pets, component: 'pet-list' }
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


        selectMenu(menuItems[0]);

        return {
            menuItems,
            currentComponent,
            selectMenu,
            isSelected
        }
    }
});