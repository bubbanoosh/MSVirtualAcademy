

$(function () {
    var ajaxSubmitForm = function () {

        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        //Pass the data to the callback .done()
        // show the response in the target id that was specified in the form
        $.ajax(options).done(function (data) {

            //The part of the page to replace with the response
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
        });

        return false;

    };


    var submitAutoCompleteForm = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };


    var createAutoComplete = function () {

        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutoCompleteForm
        };

        $input.autocomplete(options);
    };

    //For pagedList below
    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            type: "get"
        };
    };

    $("form[data-otf-ajax='true']").submit(ajaxSubmitForm);
    $("input[data-otf-autocomplete]").each(createAutoComplete);

    //JQuery  Ajax for pagination with PagedList
    $(".main-content").on("click", ".pagedList a", getPage);
});