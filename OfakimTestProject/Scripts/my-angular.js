var app = angular.module('myApp', ['ngSanitize']);
app.controller('MyAppController', MyAppController);

function MyAppController() {
    var self = this;

    self.filterSource = {};
    self.filterPair = {};

    self.sources = {};
    self.pairs = {};
    self.data = {};

    self.init = init;
    self.filterBySource = filterBySource;
    self.filterByPair = filterByPair;


    function init(modelSources, modelPairs, modelData) {
        self.sources = modelSources;
        self.pairs = modelPairs;
        self.data = modelData;

        self.sources.forEach(function (item) {
            self.filterSource[item.Id] = true;
        });

        self.pairs.forEach(function (item) {
            self.filterPair[item.Id] = true;
        });
    }

    function filterBySource(data) {
        return self.filterSource[data.SourceId];
    }

    function filterByPair(data) {
        return self.filterPair[data.PairId];
    }

}


