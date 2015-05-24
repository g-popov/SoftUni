app.controller('AuthController',
    function($scope, $location, authService){

        $scope.login = function(userData) {
            authService.login(userData,
                function success() {
                    $location.path('/home');
                },
                function error(err){
                    console.log(err);
                }
            );
        }

        $scope.register = function(userData) {
            authService.register(userData,
                function success() {
                    $location.path('/home');
                },
                function error(err){
                    console.log(err);
                }
            );
        }
    }
);