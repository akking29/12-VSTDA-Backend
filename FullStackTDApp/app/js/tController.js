angular.module('toDo',[]);

angular.module('toDo').controller('tCtrl', ['$scope', '$log','tFactory', function($scope, $log, tFactory){
	
	$scope.tasks = [];

	tFactory.getTasks().then(
		function(response){
			$scope.tasks = response.data;
			console.log($scope.tasks);
		});

	$scope.addTask= function (toDoTask){
		tFactory.postTasks(tFactory.toDoTask).then(
		function (response){
			$scope.tasks.push(response.data);
			console.log(response.data);
		});		

		$scope.addTask={};
	};

	$scope.predicate='priority';
	$scope.reverse = true;
	$scope.sort = function(predicate){
		$scope.reverse = ($scope.predicate === predicate) ?! $scope.reverse : false;
		$scope.predicate = predicate;

	};


	$scope.getTask = function(task){

		switch(task.priority) {
			case "1": return 'danger';
			case "2": return 'warning';
			case "3": return 'info';
		}
	};

}]);
