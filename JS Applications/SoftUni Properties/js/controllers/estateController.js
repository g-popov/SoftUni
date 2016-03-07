var app = app || {};

app.estateController = (function () {
    function EstateController(model){
        this.model = model;
    }

    EstateController.prototype.loadAllEstates = function(selector){
        this.model.listAllEstates()
            .then(function(data){
                $.get('templates/estatesList.html', function(template){
                    var outHtml = Mustache.render(template, data);
                    $(selector).html(outHtml);
                })
            }, function(error){
                console.log(error.message);
            });
    };

    EstateController.prototype.loadAddEstate = function(selector){
        _this = this;
        $.get('templates/addEstate.html', function(template){
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
            .then(function(){
                $('#add-estate-button').click(function(){
                    var name = $('#name').val();
                    var category = {
                        __type : 'Pointer',
                        className: 'Category',
                        objectId: $('#category').val()
                    };
                    var price = Number($('#price').val());
                    _this.model.addEstate(name, category, price)
                        .then(function(){
                            window.location.replace('#/estates/');
                        }, function(error){
                            console.log(error.message);
                        });
                })
            })
    };

    EstateController.prototype.loadEditEstate = function(selector, urlParams){
        var estatesData = splitUrl(urlParams);
        var _this = this;

        $.get('templates/editEstate.html', function(template){
            var outHtml = Mustache.render(template, estatesData);
            $(selector).html(outHtml);
        })
            .then(function(){
                $('#edit-estate-button').click(function(){
                    var id = estatesData.id;
                    var name = $('#item-name').val();
                    var price = Number($('#price').val());

                    _this.model.editEstate(id, name, price)
                        .then(function(){
                            window.location.replace('#/estates/')
                        }, function(error){
                            console.log(error.message);
                        })
                })
            })
    };

    EstateController.prototype.loadDeleteEstate = function(selector, urlParams){
        var estatesData = splitUrl(urlParams);
        var _this = this;

        $.get('templates/deleteEstate.html', function(template){
            var outHtml = Mustache.render(template, estatesData);
            $(selector).html(outHtml);
        })
            .then(function(){
                $('#delete-estate-button').click(function(){
                    var id = estatesData.id;
                    _this.model.deleteEstate(id)
                        .then(function(){
                            window.location.replace('#/estates/')
                        }, function(error){
                            console.log(error.message);
                        })
                })
            })
    };

    function splitUrl(urlParams){
        var data = urlParams.split('&');
        var estatesData = {
            id : data[0].split('id=')[1],
            name: data[1].split('name=')[1],
            category: data[2].split('category=')[1],
            price: data[3].split('price=')[1]
        };
        return estatesData;
    }


    return {
        load: function(model){
            return new EstateController(model);
        }
    }
}());