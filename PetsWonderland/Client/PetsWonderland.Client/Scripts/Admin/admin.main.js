$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function showpreview(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {          
            $(input).next().css('display', 'block');
            $(input).next().attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}