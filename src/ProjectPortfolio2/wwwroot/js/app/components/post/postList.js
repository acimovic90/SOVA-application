define(['knockout', 'dataservice', 'config'], function (ko, dataService, config) {
    return function () {
        var posts = ko.observableArray([]);
        var selectedPost = ko.observable();

        var selectPost = function (post) {
            selectedPost(post);
            postman.publish(config.events.selectPerson, post);
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
            //isSelected
        };
    };
});
