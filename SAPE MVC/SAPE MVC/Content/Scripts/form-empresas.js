$(function () {
    $.getJSON("/Form/getEmpresas")
   .done(function (data) {
       $('#nombreEmpresa').autocomplete({
           lookup: data,
           onSelect: function (suggestion) {
           }
       });
   });

    $("form").validity(function () {
        $("#nombreEmpresa").require();
        $("#nombreContacto").require();
        $("#papellidoContacto").require();
        $("#sapellidoContacto").require();
        $("#telContacto")
            .require()
            .match("number");
        $("#emailContacto")
            .require()
            .match("email");
    });

});