

my.resumeListPartial = (function (util) {
    if (!util)
        console.log("my.utility is not loaded");



    //selected items
    var checked = [];

    function init() {
        $("#allResumesChk").change(function () {
            checked = [];
            if (this.checked == true) {
                //add all
                $(".resumeChk").each((i, e) => {
                    checked.push(e.dataset.id);
                }).prop("checked", true);
            } else {
                //remove all                
                $(".resumeChk").prop("checked", false);
            }
        });

        $(".descDropDiv").hide();
        $(".descDropSpan").text("▼").click(function () {
            var targ = $(this).parent().find("div");
            if ($(targ).is(":visible")) {
                $(this).text("▼");
                $(targ).slideUp(200);
            } else {
                $(this).text("▲");
                $(targ).slideDown(200);
            }
        });
        

    };
    //get data from server
    function getList() {
        util.block("#resumeList", true);
        $.get("/Resume/GetResumes").then(function (resp) {
            $("#resumeList").html(resp);
            util.block("#resumeList", false);            
        });
    };

    function check(el, id) {
        if (el.checked == true) {
            checked.push(id);                
        } else {
            util.removeArrayItem(checked, id);          
        }
        updateCheckAll();
    };   
    function updateCheckAll()
    {
        var allChk = true;
        $(".resumeChk").each((i, e) => {
            if (e.checked == false)
                allChk = false;
        });
        $("#allResumesChk").prop("checked", allChk);
    };
    

    return {
        init: init,
        getList: getList,
        check: check,
        selectedResumes: checked
    };

})(my.utility);