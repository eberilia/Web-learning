// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var max_fields = 6;
    var div = $("#additional_answer");
    var add_button = $("#add_answer");
    var select_type = $("#type_question");
    var answers = $("#answers");
    var x = 0;

    $(add_button).click(function (e) {
        e.preventDefault();
        if (x < max_fields) {
            x++;
            if (x == max_fields) {
                $(add_button).addClass("disabled");
                console.log('You Reached the limits')
            }
            var q_id = 'qa' + (x + 2)
            var b_id = q_id + '_bool'
            var b_name = 'qbool'
            var b_val = 'q' + (x + 2)

            var text = ''
            text += '<div class="input-group">'
                text += '<div class="input-group-prepend">'
                    text += '<div class="input-group-text">'
            text += '<input type="'+select_type.val()+'" id="' + b_id + '" name="' + b_name + '" value="' + b_val+'">'
                        text += '<a href = "#" class="delete" >Usuń</a>'
                    text += '</div>'
                text += '</div>'
            text += '<input type="text" class="form-control"  id="' + q_id + '" name="' + q_id+'" value="" placeholder="Treść odpowiedzi" required>'
            text += '</div>'

            $(add_button).before(text);
          }
    });

    $(div).on("click", ".delete", function (e) {
        if (x == max_fields)
            $(add_button).removeClass("disabled");
        e.preventDefault();
        $(this).parent().parent().parent().remove();
        x--;
    })

    $(select_type).change(function () {
        var selected = $(this).val()
        $(answers).find(".input-group-text input").each(function () {
            this.type = selected
        })

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

