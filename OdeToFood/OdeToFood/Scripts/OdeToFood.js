/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery-ui.js" />
/// <reference path="jQuery.tmpl.js" />

$(document).ready(function () {

    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({ source: $(this).attr("data-autocomplete") });
    });
    $(":input[data-datepicker]").datepicker();
})