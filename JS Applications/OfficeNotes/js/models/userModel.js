var app = app || {};

app.userModel = (function(){
    function UserModel(baseUrl, requester, headers){
        this._baseUrl = baseUrl;
        this._requester = requester;
        this._headers = headers;
    }

    UserModel.prototype.register = function(username, password, fullName){
        var serviceUrl = this._baseUrl + 'users';
        var userData = {
            username: username,
            password: password,
            fullName: fullName
        };

        return this._requester.post(serviceUrl, this._headers.getHeaders(), userData)
    };

    UserModel.prototype.login = function(username, password){
        var serviceUrl = this._baseUrl + 'login?username=' + username + '&password=' + password;

        return this._requester.get(serviceUrl, this._headers.getHeaders());
    };

    UserModel.prototype.logout = function(){
        var serviceUrl = this._baseUrl + 'logout';

        return this._requester.post(serviceUrl, this._headers.getHeaders());
    };

    return {
        load: function(baseUrl, requester, headers){
            return new UserModel(baseUrl, requester, headers)
        }
    }
}());