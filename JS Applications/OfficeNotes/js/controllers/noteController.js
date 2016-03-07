var app = app || {};

app.noteController = (function () {
    function NoteController(noteModel){
        this._noteModel = noteModel;
    }

    NoteController.prototype.loadOfficeNotesScreen = function(selector){
        var date = getCurrentDate();
        this._noteModel.listTodayDeadlineNotes(date)
            .then(function(data){
                $.get('templates/officeNoteTemplate.html', function(template){
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                });
            }, function(error){
                console.log(error);
            });
    };

    NoteController.prototype.loadUserNotesScreen = function(selector){
        var currentUser = sessionStorage['fullName'];
        this._noteModel.listMyNotes(currentUser)
            .then(function(data){
                $.get('templates/myNoteTemplate.html', function(template){
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                })
                    .then(function(){
                        $('.edit').click(function(){
                            window.location.replace('#/editNote/');
                        });
                        $('.delete').click(function(){
                            window.location.replace('#/deleteNote/');
                        });
                    });
            },function(error){
                console.log(error);
            });

    };

    NoteController.prototype.loadAddNoteScreen = function(selector){
        var _this = this;
        $.get('templates/addNote.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        })
            .then(function(){
                $('#addNoteButton').click(function(){
                    var title = $('#title').val();
                    var text =  $('#text').val();
                    var author = sessionStorage['fullName'];
                    var deadline = $('#deadline').val();

                    _this._noteModel.addNote(title, text, author, deadline)
                        .then(function(){
                            window.location.replace('#/myNotes/')
                        }, function(error){
                            console.log(error.message);
                        });
                });
            });
    };

    NoteController.prototype.loadEditNoteScreen = function(selector){
        $.get('templates/editNote.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        })
    };

    NoteController.prototype.loadDeleteNoteScreen = function(selector){
        $.get('templates/deleteNote.html', function(template){
            var output = Mustache.render(template);
            $(selector).html(output);
        })
    };

    function addNote(){

    }

    function getCurrentDate(){
        var dateNow = new Date();
        var year = dateNow.getFullYear();
        var month = ("0" + (dateNow.getMonth() + 1)).slice(-2);
        var day = ("0" + dateNow.getDate()).slice(-2);
        return year + '-' + month + '-' + day;
    }

    return {
        load: function(noteModel){
            return new NoteController(noteModel);
        }
    }
}());
