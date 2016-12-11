define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function (params) {
        var words = ko.observable();
        var cloudWords = ko.observableArray([]);
        var cloudData = [];

        var search = function () {
            var searchString = words();
            dataService.getWordCloudWords(searchString, function (data) {
                cloudWords(data);
                debugger;

                for (var i = 0; i < data.length; i++) {
                    cloudData.push({ text: data[i].word, weight: data[i].count });
                }
                $('#keywords').jQCloud(cloudData);
                $('#keywords').text('tetetetetet');
            });
        }

        

        return {
            cloudWords,
            words,
            search            
        };
    };
});
