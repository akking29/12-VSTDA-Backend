angular.module('toDo')
	.factory('tFactory', tFactory);

		tFactory.$inject = ["$http", "$q", "$log"]; //maybe need ""

		function tFactory($http, $q, $log) {
       var service = {
       
           getTasks: getTasks //, if more functions
       
       };
       
       return service;

       ////////////////

       function getTasks() {
           var defer = $q.defer();
           $http({
                   method: 'GET',
                   url: 'http://localhost:61477/api/ToDoTasks'
               })
               .then(
                   function(response) {
                       if (typeof response.data === 'object') {
                           defer.resolve(response);
                           toastr.success('We stuff to do!');
                       } else {
                           defer.reject(response);
                           toastr.warning('no top spots found <br/>' + response.config.url);
                       }
                   },
                   //failure
                   function(error) {
                       defer.reject(error);
                       $log.error(error);
                       toastr.error('error: '+ error.data + '<br/>status: ' + error.statusText);
                   });
           
           return defer.promise;

       }
   };