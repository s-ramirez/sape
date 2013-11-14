jQuery(document).ready(function ($) {
    $("#item-Calificaciones").addClass('active');

    var table = $("#tabla-empresas");
    var oTable = table.dataTable({ "sPaginationType": "full_numbers", "bStateSave": true });

    $('.editable').editable(function (value, settings) {
        $.getJSON("/Main/SaveCalifs", {
            id: this.id,
            value: value,
            format: "json"
        })
        .done(function (data) {
            alert("El numero de carne no pertenece a ningun estudiante del sistema");
        });
        console.log(this.id);
        console.log(value);
        console.log(settings);
        return (value);
    }, {
        type: 'text',
        submit: 'Guardar',
    });
});