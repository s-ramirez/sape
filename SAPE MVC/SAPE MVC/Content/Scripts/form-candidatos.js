$(function () {
    $("form").validity(function () {
        $("#nombreCand")
            .require();
        $("#prmApellidoCand").require();
        $("#sdoApellidoCand").require();
        $("#carnetCand")
            .require()
            .match("number");
        $("#telCand")
            .require()
            .match("number");
        $("#correoCand")
            .require()
            .match("email");
    });

});