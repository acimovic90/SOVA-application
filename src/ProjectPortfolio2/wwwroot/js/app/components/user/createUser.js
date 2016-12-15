define(['knockout', 'dataservice', 'jquery','postman', 'config'], function (ko, dataService,$,postman, config) {
    return function () {
        var displayname = ko.observable();
        var age = ko.observable();
        var location = ko.observable(); 

        var createUser = function () {
            if (displayname() == undefined || displayname() == "" || age() == undefined || age() == "" || location() == undefined || location == "") {
                $('.alertField')
                    .html('<div class="alert alert-danger">' +
                        '<strong>Ops!</strong> Please enter all required fields' +
                        '</div>');
                return false;
            }

            $('.alertField').html("");

            dataService.createUser({ Displayname: displayname(), Age: age(), Location: location() }, function (data) {             
                $('.alertField')
                    .html('<div class="alert alert-success">' +
                        '<strong>Success!</strong> User ' +
                        displayname() +
                        ' is created. <button onclick="selectUser('+data.id+')" class="pull-right btn btn-xs btn-success viewProfileBtn">View Profile</button>' +
                        '</div>');
            });
        }

        self.selectUser = function (id) {
            dataService.getSingleUser(id, function (data) {
                postman.publish(config.events.selectUser, { user: data });
            });
        }

        return {
            displayname,
            age,
            selectUser,
            location,
            createUser
        };
    };
});
