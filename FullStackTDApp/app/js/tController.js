angular.module('toDo',[]);

angular.module('toDo').controller('tCtrl', ['$scope', '$log','tFactory', function($scope, $log, tFactory){

		tFactory.getTasks().then(
		function(response){
			$scope.tasks = response.data;
			console.log($scope.tasks);
		});


		$scope.addTask= function (toDoTask){
		tFactory.postTasks(toDoTask).then(
		function (response){
			toastr.success('"' + response.data.text + '" was added!')
			$scope.tasks.push(response.data);
			
		});		

		$scope.newTask={};
	};

	$scope.editTask = function(toDoTaskId,index){
		tFactory.editTasks(toDoTaskId).then(
			function(response){
				console.log(response.data);
				toastr.success('"' + response.data.text + '" was edited');

			});

	};

	$scope.deleteTask = function(toDoTaskId,index){
		tFactory.deleteTasks(toDoTaskId).then(
			function(response){
				$scope.tasks.splice(index,1);
				console.log(response.data);
				toastr.success('"' + response.data.text + '" was deleted');

			});

	};

	$scope.predicate='priority';
	$scope.reverse = true;
	$scope.sort = function(predicate){
		$scope.reverse = ($scope.predicate === predicate) ?! $scope.reverse : false;
		$scope.predicate = predicate;

	};

}]);
