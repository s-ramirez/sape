/// <reference path="jquery.js" />

jQuery(document).ready(function ($) {
    $("#tabla-empresas").tablesorter();
    $("#item-RegistroEmpresas").addClass('active');

});

function openMailModal() {
    var mailList = "";
    var correos = 0;
    $('#tabla-body tr').each(function () {
        var count = $(this).find('input[type=checkbox]:checked').length;
        if (count > 0) {
            mailList += $(this).find('td.emailEmpresa').text()+",";
            correos++;
        }
    });
    if (correos > 0) {
        mailList = mailList.slice(0, -1);
    }

    $('#mailList').val(mailList);
    $('#sendMailModal').modal('show');
}