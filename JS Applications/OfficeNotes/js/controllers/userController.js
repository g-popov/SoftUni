var app = app || {};

app.userController = (function () {
    function UserController(userModel){
        this._userModel = userModel;
    }

    UserController.prototype.loadWelcomeScreen = function(selector){
        $.get('templates/welcome.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    };

    UserController.prototype.loadLoginScreen = function(selector){
        _this = this;
        $.get('templates/login.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        })
            .then(function(){
                $('#loginButton').click(function(){
                    var user = $('#username').val();
                    var pass = $('#password').val();
                    _this._userModel.login(user, pass)
                        .then(function(data){
                            setSessionStorage(data);
                            window.location.replace('#/home/');
                        }, function(error){
                            console.log(error.message);
                        });
                });
            });
    };

    UserController.prototype.loadRegisterScreen = function(selector){
        var _this = this;
        $.get('templates/register.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        })
            .then(function(){
                $('#registerButton').click(function(){
                    var user = $('#username').val();
                    var pass = $('#password').val();
                    var fullName = $('#fullName').val();
                    _this._userModel.register(user, pass, fullName)
                        .then(function(regData){
                            data = {
                                objectId: regData.objectId,
                                username: user,
                                fullName: fullName,
                                sessionToken: regData.sessionToken
                            }
                            setSessionStorage(data);
                            window.location.replace('#/home/');
                        }, function(error){
                            console.log(error.message);
                        });
                });
            });
    };

    UserController.prototype.loadHomeScreen = function(selector){
        var userData = {
            username: sessionStorage['username'],
            fullName: sessionStorage['fullName']
        };
        $.get('templates/home.html', function(template){
            var output = Mustache.render(template, userData);
            $(selector).html(output);
        })
    };

    UserController.prototype.logout = function(){
        this._userModel.logout()
            .then(function(){
                clearStorage();
                window.location.replace('#/');
            });
    };

    UserController.prototype.isLogged = function(){
        if(sessionStorage['sessionToken']){
            return true;
        }
        else {
            return false;
        }
    };

    function setSessionStorage(data){
        sessionStorage['userId'] = data.objectId;
        sessionStorage['username'] = data.username;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearStorage(){
        delete sessionStorage['userId'];
        delete sessionStorage['username'];
        delete sessionStorage['fullName'];
        delete sessionStorage['sessionToken'];

    }

    return {
        load: function (userModel){
            return new UserController(userModel);
        }
    }
}());