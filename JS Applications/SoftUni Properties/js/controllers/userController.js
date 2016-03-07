var app = app || {};

app.userController = (function () {
    function UserController(model){
        this.model = model;
    }

    UserController.prototype.loadGuestHome = function(selector){
        $.get('templates/welcomeGuest.html', function(template){
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
    };

    UserController.prototype.loadLoginPage = function(selector){
        var _this = this;
        $.get('templates/login.html', function(template){
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
            .then(function(){
                $('#login-button').click(function(){
                    var username = $('#username').val();
                    var password = $('#password').val();
                    _this.model.login(username, password)
                        .then(function(data){
                            setCredentials(data);
                            window.location.replace('#/home/');
                        }, function(error){
                            console.log(error.message);
                        });
                });
            })
    };

    UserController.prototype.loadRegisterPage = function(selector){
        var _this = this;
        $.get('templates/register.html', function(template){
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
            .then(function(){
                $('#register-button').click(function(){
                    var username = $('#username').val();
                    var password = $('#password').val();
                    var confirmPassword = $('#confirm-password').val();
                    if(password == confirmPassword){
                        _this.model.register(username, password)
                            .then(function(regData){
                                var data = {
                                    objectId: regData.objectId,
                                    username: username,
                                    sessionToken: regData.sessionToken
                                }
                                setCredentials(data);
                                window.location.replace('#/home/');
                            }, function(error){
                                console.log(error.message);
                            });
                    }
                });
        })
    };

    UserController.prototype.loadUserHome = function(selector){
        var userData = {
            username: sessionStorage['username']
        };
        $.get('templates/welcomeUser.html', function(template){
            var outHtml = Mustache.render(template, userData);
            $(selector).html(outHtml);
        })
    };

    UserController.prototype.logout = function(){
        this.model.logout()
            .then(function(){
                clearSessionStorage();
                window.location.replace('#/');
            }, function(error){
                console.log(error.message);
            });
    };

    UserController.prototype.isLogged = function(){
        UserController.prototype.isLogged = function(){
            if(sessionStorage['sessionToken']){
                return true;
            }
            else {
                return false;
            }
        };
    };

    function setCredentials (data){
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearSessionStorage(){
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['sessionToken']
    }

    return {
        load: function(model){
            return new UserController(model);
        }
    }
}());