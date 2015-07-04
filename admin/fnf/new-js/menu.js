function emailValidation(email) {
	var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	return re.test(email);
}
var app = angular.module('registration', []);
app.controller('regCtrl', function ($scope, regService) {
	$scope.register = function () {
		var data = regService.registerUser($scope);
	};
	$scope.login = function () {
		var data = regService.login($scope);
	};
	$scope.validateEmail = function () {
		if (emailValidation($scope.login.email)) {
			regService.checkEmail($scope);
		}
	};
    $scope.validateRegEmail = function () {
		if (emailValidation($scope.user.email)) {
			regService.checkRegEmail($scope);
		}
	};
    
	$scope.removeErro = function (name) {
		try {
			delete $scope.user.errors[name];
			//delete $scope.user.errors.info;

		} catch (e) { }
	};
	$scope.logout=function(){
		regService.logout();
	}
	$scope.removelogErro = function (name) {
		try {
			delete $scope.login.errors[name];
			delete $scope.login.errors.info;
		} catch (e) { }
	};
});
app.service('regService', function ($http) {
	this.registerUser = function (scope) {
		var param = {
			action: 'register',
			email: scope.user.email,
			pwd: scope.user.pwd,
			mobile: scope.user.mobile,
			gender: scope.user.gender

		};
		jQuery.ajax({ method: 'POST', url: path+'sfloor/pages/AjaxService.aspx', data: param })
					.success(function (msg) {
						if (msg.errors != null) {
							scope.$apply(function () {
								scope.user.errors = msg.errors;
							});
						} else {
							location.reload();
						}

					});
	};
	this.login = function (scope) {
		var param = {
			action: 'login',
			email: scope.login.email,
			pwd: scope.login.pwd
		};
		jQuery.ajax({ method: 'POST', url: path+'sfloor/pages/AjaxService.aspx', data: param })
					.success(function (msg) {
					console.log(msg);
						if (msg.errors != null) {
							console.log(2);
							scope.$apply(function () {
								 scope.login.errors = msg.errors;
							});
						} else {
						console.log(1);
							location.reload();
						}
					});

	};
	this.checkEmail = function (scope) {
		var param = {
			action: 'checkEmail',
			email: scope.login.email,
		};
		jQuery.ajax({ method: 'POST', url: path+'sfloor/pages/AjaxService.aspx', data: param })
					.success(function (msg) {
						if (msg.errors != null) {
							scope.$apply(function () {
								scope.login.errors = msg.errors;
							});
						} else {
							
						}
					});

	};
    this.checkRegEmail = function (scope) {
		var param = {
			action: 'checkRegEmail',
			email: scope.user.email,
		};
		jQuery.ajax({ method: 'POST', url: path+'sfloor/pages/AjaxService.aspx', data: param })
					.success(function (msg) {
						if (msg.errors != null) {
							scope.$apply(function () {
								scope.user.errors = msg.errors;
							});
						} else {
							
						}
					});
	};
});

