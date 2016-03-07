var app = app || {};

(function(){
    var applicationId = 'l0U47xILbxzwipo9he4ckp0D5QFn5h3AStAq2GlW';
    var restApiKey = 'lrsECpmZzJOX2VVr64Q8WEzlRpBJHzj1GF5KtkzC';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(applicationId, restApiKey);
    var requester = app.requester.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var estateModel = app.estateModel.load(baseUrl, requester, headers);

    var userController = app.userController.load(userModel);
    var estateController = app.estateController.load(estateModel);

    app.router = Sammy(function(){
        var menuSelector = $('#menu');
        var mainSelector = $('#main');

        this.before(function(){
            if(userController.isLogged()){
                $('#userMenu').show();
                $('#guestMenu').hide();
            }
            else {
                $('#userMenu').hide();
                $('#guestMenu').show();
            }
        })

        this.before('#/', function(){
            if(userController.isLogged()){
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/login/', function(){
            if(userController.isLogged()){
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/register/', function(){
            if(userController.isLogged()){
                this.redirect('#/home/');
                return false;
            }
        });

        this.before('#/home/', function(){
            if(!userController.isLogged()){
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/logout/', function(){
            if(!userController.isLogged()){
                this.redirect('#/');
                return false;
            }
        });

        this.before('#/estates/(.*)', function(){
            if(!userController.isLogged()){
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function(){
            userController.loadGuestHome(mainSelector);
        });

        this.get('#/login/', function(){
           userController.loadLoginPage(mainSelector);
        });

        this.get('#/register/', function(){
            userController.loadRegisterPage(mainSelector);
        });

        this.get('#/home/', function(){
            userController.loadUserHome(mainSelector);
        });

        this.get('#/logout/', function(){
            userController.logout();
        });

        this.get('#/estates/', function(){
            estateController.loadAllEstates(mainSelector);
        });

        this.get('#/estates/add/', function(){
            estateController.loadAddEstate(mainSelector);
        });

        this.get('#/estates/edit/:id/', function(){
            estateController.loadEditEstate(mainSelector, this.params['id']);
        });

        this.get('#/estates/delete/:data/', function(){
            estateController.loadDeleteEstate(mainSelector, this.params['data']);
        });

    });

    app.router.run('#/');
}());