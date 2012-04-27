$(document).ready(function () {

    $(":input[data-autocomplete]").each(function () {
        $(this).autocomplete({ source: $(this).attr("data-autocomplete") });
    });
    $(":input[data-datepicker]").datepicker();
})