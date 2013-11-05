var cantDislikes = 1;

$(document).ready(function () {
    var prefInputs = document.getElementsByClassName('pref');
});

function slideDivDown() {
    $.getJSON ("/Form/CheckCarne", {
        carne : $("#lcarnet").val(),
        format: "json"
    })
    .done(function (data) {
        var array = data.split(",");
        if (array[0] == "true") {
            $("#form-body").slideDown('slow');
            $("#NombreEst").val(array[2]);
        }
        else {
            alert("El numero de carne no pertenece a ningun estudiante del sistema");
        }
    });
}

function addMore () {
    if (cantDislikes < 5) {
        cantDislikes += 1;
        $("#dislike"+cantDislikes).slideDown('slow');
    }
}