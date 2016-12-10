﻿define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService,postman, config) {
    return function () {
        var posts = ko.observableArray([]);

        var selectPost = function (post) {
            postman.publish(config.events.selectPost, post);
        }



        //var isSelected = function (person) {
        //    return person === selectedPerson();
        //}

        //postman.subscribe(config.events.savePerson, function (person) {
        //    var personArray = persons();
        //    for (var i = 0; i < personArray.length; i++) {
        //        if (personArray[i].id === person.id) {
        //            personArray[i] = person;
        //            break;
        //        }
        //    }
        //    persons(personArray);
        //    selectedPerson(person);
        //});

        dataService.getPosts(function (data) {
            posts(data.posts);
        });

        return {
            posts,
            selectPost
        };
    };
});
