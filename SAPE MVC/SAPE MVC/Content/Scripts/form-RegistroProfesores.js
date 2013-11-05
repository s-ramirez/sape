$("form").validity(function () {
    $("#nombreProfesor").require();
    $("#prmApeProf").require();
    $("#sdoApeProf").require();
    $("#teleProfe")
        .require()
        .match("number");
    $("#correoProfe")
        .require()
        .match("email");
});

