app.factory('authService',
    function($http, baseUrl) {
        function login(userData, success, error){
            $http({
                method: 'POST',
                url: baseUrl + '/users/login',
                data: userData
            }).success(function(data){
                setCredentials(data);
                success(data);
            }).error(error);
        }

        function register(userData, success, error) {
            $http({
                method: 'POST',
                url: baseUrl + '/users/register',
                data: userData
            }).success(function(data){
                setCredentials(data);
                success(data);
            }).error(error);
        }

        function setCredentials(responseData){
            sessionStorage['accessToken'] = responseData.access_token;
            sessionStorage['userName'] = responseData.userName;
        }

        function logout() {

        }

        return {
            login: login,
            register: register,
            logout: logout
        }
    }
);
