// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//var tokenCaptcha = '';
//var nombreFormulario = '';
function onSubmit(token) {
    debugger;
    console.log(token);
   // if ($('#' + nombreFormulario).valid()) {
    if (token != null) {
        $("#rC").val(token);
       
        document.forms[0].submit();
   
        
    }
   // }
    

}




$(document).ready(function () {

    /*$('#' + nombreFormulario).validate({
        rules: {
            status: {
                required: true,
                minlength: 10
            },
            date: {
                required: true,
            }
        },
        messages: {
            status: {
                required: "*"
            },
            date: {
                required: "*"
            }
        }
    });*/

});

