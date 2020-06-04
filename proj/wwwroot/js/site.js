// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var max_fields = 6;
    var div = $("#additional_answer");
    var add_button = $("#add_answer");
    var prefix = "q"

    var x = 0;
    $(add_button).click(function (e) {
        e.preventDefault();
        if (x < max_fields) {
            x++;
            if (x == max_fields) {
                $(add_button).addClass("disabled");
                console.log('You Reached the limits')
            }
            var id = 'qa' + (x + 2)
            var id_b = id + 'bool'
            var text = ''
            text += '<div class="form-group">'
            text += '<label for="' + id + '" class="control-label">Treść odpowiedzi</label>'
            text += '<input type="text" id="' + id + '" name="' + id + '" class="form-control" value="" placeholder="Treść odpowiedzi" required />'
            text += '<input type="checkbox" class="form-check-input" id="' + id_b + '" name="' + id_b + '"value="true" />'
            text += '<label for="' + id_b + '" class="form-check-label">Prawidłowa?</label>'
            text += '<a href = "#" class="delete" >Usuń</a>'
            text += '</div>'


            $(add_button).before(text);
            //$(div).append(text);


            //$(div).append('<div><input type="text" name="mytext[]" /><a href="#" class="delete">Delete</a></div>'); //add input box
            //$(wrapper).append('<div><div class="form-group">< label for="q1a1" class="control-label" > Treść odpowiedzi</label ><input type="text" id="q1a1" name="q1a1" class="form-control" value="" placeholder="Treść odpowiedzi" required /></div ><div class="form-group form-check"><label for="q1a1bool" class="form-check-label">Prawidłowa?</label><input type="checkbox" class="form-check-input" id="q1a1bool" value="true" /> </div>< a href="#" class="delete" > Delete</a ></div > '); //add input box
        }

    });

    $(div).on("click", ".delete", function (e) {
        if (x == max_fields)
            $(add_button).removeClass("disabled");
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    })
});


$(document).ready(function () {
    $("#category").change(function(){
        var category = $(this).val()

        if (category == "All")
            $("#quizes section").each(function (i, button) {
                $(button).show(300)
            });
        else
            $("#quizes section").each(function (i, button) {
                if ($(button).hasClass(category))
                    $(button).show(300)
                else
                    $(button).hide(300)
            });
    });
});

/*
 * if (category == "All")
            $("#quizes button").each(function (i, button) {
                    $(button).show(300)
            });
        else
        $("#quizes button").each(function(i, button){
            if($(button).hasClass(category))
                $(button).show(300)
            else
                $(button).hide(300)
        });
 * 
 * 
 * */