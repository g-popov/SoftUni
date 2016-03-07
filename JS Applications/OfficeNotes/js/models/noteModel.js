var app = app || {};

app.noteModel = (function () {
    function NoteModel(baseUrl, requester, headers){
        this._baseServiceUrl = baseUrl + 'classes/Note';
        this._requester = requester;
        this._headers = headers;
    }

    NoteModel.prototype.listTodayDeadlineNotes = function(date){
        var serviceUrl = this._baseServiceUrl + '?where={"deadline":"' + date + '"}';

        return this._requester.get(serviceUrl, this._headers.getHeaders());
    };

    NoteModel.prototype.listMyNotes = function(author){
        var serviceUrl = this._baseServiceUrl + '?where={"author":"' + author +'"}';

        return this._requester.get(serviceUrl, this._headers.getHeaders());
    };

    NoteModel.prototype.addNote = function(title, text, author, deadline){
        var userId = sessionStorage['userId'];
        var noteData = {
            title: title,
            text: text,
            author: author,
            deadline: deadline,
            /*ACL:{
            }*/
        };

        return this._requester.post(this._baseServiceUrl, this._headers.getHeaders(), noteData);
    };

    NoteModel.prototype.editNote = function(noteId, title, text, author, deadline){
        var serviceUrl = this._baseServiceUrl + '/' + noteId;
        var noteData = {
            title: title,
            text: text,
            author: author,
            deadline: deadline
        };

        return this._requester.put(serviceUrl, this._headers.getHeaders(), noteData);
    };

    NoteModel.prototype.deleteNote = function(noteId){
        var serviceUrl = this._baseServiceUrl + '/' + noteId;

        return this._requester.remove(serviceUrl, this._headers.getHeaders());
    };

    return {
        load: function(baseUrl, requester, headers){
            return new NoteModel(baseUrl, requester, headers);
        }
    }
}());