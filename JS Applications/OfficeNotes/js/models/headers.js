var app = app || {};

app.headers = (function(){
    function Headers(applicationId, restApiKey){
        this._applicationId = applicationId;
        this._restApiKey = restApiKey;
    }

    Headers.prototype.getHeaders = function(){
        var headers = {
            'X-Parse-Application-Id': this._applicationId,
            'X-Parse-REST-API-Key': this._restApiKey
        };

        if(sessionStorage['sessionToken']){
            headers['X-Parse-Session-Token'] = sessionStorage['sessionToken'];
        }

        return headers;
    }

    return {
        load: function(applicationId, restApiKey){
            return new Headers(applicationId, restApiKey);
        }
    }
}());
