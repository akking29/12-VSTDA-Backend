(function() {
    'use strict';

    angular
        .module('toDo')
        .directive('convertToNumber', convertToNumber);

    /* @ngInject */
    function convertToNumber() {
        var directive = {
            require: 'ngModel',
            link: link,
        };
        return directive;

        function link(scope, element, attrs, ngModel) {
            ngModel.$parsers.push(function(val) {
              return val ? parseInt(val, 10) : null;
            });
            ngModel.$formatters.push(function(val) {
              return val ? '' + val : null;
            });
        }
    }
})();