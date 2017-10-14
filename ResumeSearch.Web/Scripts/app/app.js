
//global namespace
window.my = window.my || {};

//setup
//jQuery
(function ($) {
    $.fn.clickSummary = function () {
        $(this).click(function () { alert(); });
    }

})(jQuery);




my.utility = (function () {
    function block(selector, isBlocked) {
        var loader = '<img src="/Content/loaders/loader.gif" />';
        if (isBlocked == true)
            $(selector).block({ message: loader });
        else
            $(selector).unblock({ message: loader });
    };
    function removeArrayItem(array, item) {
        if (!Array.isArray(array))
            throw "my.utility.removeArrayItem requires valid array.";

        var idx = array.indexOf(item);
        if (idx < 0)
            return;
        array.splice(idx, 1);
    };

    return {
        block: block,
        removeArrayItem: removeArrayItem
    }
})();