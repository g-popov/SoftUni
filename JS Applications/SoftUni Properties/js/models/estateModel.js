var app = app || {};

app.estateModel = (function () {
    function EstateModel(baseUrl, requester, headers){
        this.baseServiceUrl = baseUrl + 'classes/Estate';
        this.requester = requester;
        this.headers = headers;
    }

    EstateModel.prototype.listAllEstates = function(){
        var serviceUrl = this.baseServiceUrl + '?include=category';

        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    EstateModel.prototype.addEstate = function(name, category, price){
        var userId = sessionStorage['userId'];
        var estateData = {
            name: name,
            category: category,
            price: price,
            ACL: {}
        };

        estateData.ACL[userId] = {"write":true,"read":true};
        estateData.ACL["*"] = {"read":true};

        return this.requester.post(this.baseServiceUrl, this.headers.getHeaders(), estateData);
    };

    EstateModel.prototype.editEstate = function(estateId, name, price){
        var serviceUrl = this.baseServiceUrl + '/' + estateId;
        var estateData = {
            name: name,
            price: price
        };

        return this.requester.put(serviceUrl, this.headers.getHeaders(), estateData);
    };

    EstateModel.prototype.deleteEstate = function(estateId){
        var serviceUrl = this.baseServiceUrl + '/' + estateId;

        return this.requester.remove(serviceUrl, this.headers.getHeaders());
    };



    return {
        load: function(baseUrl, requester, headers){
            return new EstateModel(baseUrl, requester, headers);
        }
    }

}());