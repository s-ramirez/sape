$(function () {
    $.getJSON("/Form/getEmpresas")
   .done(function (data) {
       $('#nombreEmpresa').autocomplete({
           lookup: data,
           onSelect: function (suggestion) {
           }
       });
   });
});