define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function (params) {
        var words = ko.observable();
        var cloudWords = ko.observableArray([]);
        var cloudData = [];

        var search = function () {
            
            var searchString = words();
            dataService.getWordCloudWords(searchString, function (data) {
                cloudWords(data);

                for (var i = 0; i < data.length; i++) {
                    cloudData.push({ text: data[i].word, weight: data[i].count });
                }

                $('#keywords').jQCloud(cloudData, {
                    autoResize: true,
                height: 350
            });
            });
        }



        return {
            cloudWords,
            words,
            search
        };
    };
});
