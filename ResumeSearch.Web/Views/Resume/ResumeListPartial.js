

my.resumeListPartial = (function (util) {
    if (!util)
        console.log("my.utility is not loaded");


    

    function init() {
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
            //uncheck others  
            $(".resumeChk").each((i, e) => {
                if (e !== el)
                    $(e).prop("checked", false);
            });
        }
    };   

    

    return {
        init: init,
        getList: getList,
        check: check
    };

})(my.utility);