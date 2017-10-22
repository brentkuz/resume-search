

my.index = (function (util) {
    if (!util)
        console.log("my.utility is not loaded");

    //const selectors
    var selectors = {
        form: "#searchForm",
        searchPhrase: "#Search_Phrase"

    };

    var resumeSelected = false;
    
    function init() {

    };
    function validate() {
        var valid = true;
        valid &= ($(selectors.searchPhrase).val() != "");
        valid &= resumeSelected;

        return valid;
    };
    function submit() {
        if (validate()) {
            $(selectors.form).submit();
        } else {
            alert(false);
        }
    };

    //called by resumeListPartial to update checked status for validation
    function selected(isSelected) {
        resumeSelected = isSelected;
    };

    return {
        init: init,
        selected: selected,
        submit: submit
    }
})(my.utility);