$(function () {

    var ajaxFormSubmit = function (form) {
        var $form = $(form);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).error(function (data) {
            var $target = $($form.attr("data-otf-target-error"));
            var $newHtml = $(data.responseText);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        }).success(function (data) {
            var $target = $($form.attr("data-otf-target-success"));
            var $newHtml = $(data).find('.main-content');
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false; //impede que o form va ao servidor
    };

    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        console.log("32");

        //var $form = $input.parents("form:first");
        //$form.submit();
    }

    var createAutoComplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    }

    var getPage = function () {
        var $a = $(this);

        var options = {
            type: "get",
            data: $("form").serialize(),
            url: $a.attr("href")
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;
    }


    var openForm = function (e) {
        e.preventDefault();
        $("#createForm").removeClass("displayNone");
        $(this).addClass("displayNone");
    }

    $(".main-content").on('submit', 'form[data-otf-ajax="true"]', function (e) {
        e.preventDefault();
        ajaxFormSubmit(this);
    });

    $("input[data-otf-autocomplete]").each(createAutoComplete);

    $("body").on("click", ".pagedList a", getPage);

    $('body').on('click', '#openCreate', openForm);
});