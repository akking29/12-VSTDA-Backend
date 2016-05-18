angular.module('toDo',[]);

angular.module('toDo').controller('tCtrl', ['$scope', 'tFactory', function($scope, tFactory){

	$scope.newTask={};
	
	$scope.tasks = [];

	$scope.addTask= function (){
		$scope.tasks.push($scope.newTask);
		$scope.newTask={};
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
	
	tFactory.getTasks().then(
		function(response){
			console.log(response.data);
		});
	
}]);
