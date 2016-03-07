var app = app || {};

(function(){
    var baseUrl = 'https://api.parse.com/1/';
    var applicationId = 'fMmdaLyOK6PK6waIfk4jQnGpueuS0UZ2Xpkncv5X';
    var restApiKey = 'H5GKorw340Gb9Hh0mTkeUlaHDhaoABFC9gmP5Fuz';

    var headers = app.headers.load(applicationId, restApiKey);
    var requester = app.requester.load();
    var userModel = app.userModel.load(baseUrl, requester, headers);
    var noteModel = app.noteModel.load(baseUrl, requester, headers);

    var userController = app.userController.load(userModel);
    var noteController = app.noteController.load(noteModel);

    app.router = Sammy(function(){
        var selector = '#container';

        this.before(function(){
            if (userController.isLogged()){
                $('#menu').show();
            }
            else {
                $('#menu').hide();
            }
        })

        this.get('#/', function(){
            if(!userController.isLogged()){
                userController.loadWelcomeScreen(selector);
            }
            else {
                window.location.replace('#/home/');
            }
        });

        this.get('#/login/', function(){
            if(!userController.isLogged()){
                userController.loadLoginScreen(selector);
            }
            else {
                window.location.replace('#/home/');
            }
        });

        this.get('#/register/', function(){
            if(!userController.isLogged()){
                userController.loadRegisterScreen(selector);
            }
            else {
                window.location.replace('#/home/');
            }
        });

        this.get('#/home/', function(){
            if(userController.isLogged()){
                userController.loadHomeScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/logout/', function(){
            if(userController.isLogged()){
                userController.logout();
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/office/', function(){
            if(userController.isLogged()){
                noteController.loadOfficeNotesScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/myNotes/', function(){
            if(userController.isLogged()){
                noteController.loadUserNotesScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/addNote/', function(){
            if(userController.isLogged()){
                noteController.loadAddNoteScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/editNote/', function(){
            if(userController.isLogged()){
                noteController.loadEditNoteScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });

        this.get('#/deleteNote/', function(){
            if(userController.isLogged()){
                noteController.loadDeleteNoteScreen(selector);
            }
            else {
                window.location.replace('#/');
            }
        });
    });

    app.router.run('#/');

}());