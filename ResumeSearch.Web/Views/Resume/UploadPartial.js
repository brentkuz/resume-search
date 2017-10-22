//Module for UploadPartial.cshtml

my.uploadPartial = (function (util) {
    // jqXHRData needed for grabbing by data object of fileupload scope
    var jqXHRData;

    if (!util)
        console.log("my.utility not loaded");

    function notify(message) {
        if (message != undefined) {
            $("#uploadMessage").text("Select a file").show();
        } else {
            $("#uploadMessage").text("").hide();
        }
    }

    //init view
    function init() {
        //Initialization of fileupload
        initSimpleFileUpload();

        //Handler for "Start upload" button 
        $("#uploadBtn").on('click', function () {
            notify();
            if (jqXHRData) {
                console.log("start upload");
                util.block("#resumeUpload", true);
                jqXHRData.submit();
            } else {
                console.log("no file");
                notify("Select a file");
            }

            return false;
        });
    };

    //bind jquery file upload to control
    function initSimpleFileUpload() {
        'use strict';
        $('#uploadControl').fileupload({
            url: '/Resume/Upload',
            dataType: 'html',
            replaceFileInput: false,
            add: function (e, data) {
                jqXHRData = data;
                notify();
            },
            done: function (event, data) {                
                $("#resumeUpload").html(data.result);  
                util.block("#resumeUpload", false);
                //refresh list
                my.resumeListPartial.getList();

            },
            fail: function (event, data) {
                $("#resumeUpload").html(data.result);
                console.log("upload failed");
                util.block("#resumeUpload", false);
            }
        });
    };

    return {
        init: init
    }
})(my.utility);
