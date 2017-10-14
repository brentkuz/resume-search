//Module for UploadPartial.cshtml

my.uploadPartial = (function (util, resumeList) {
    // jqXHRData needed for grabbing by data object of fileupload scope
    var jqXHRData;

    if (!util)
        console.log("my.utility not loaded");
    if (!resumeList)
        console.log("my.resumeList not loaded");

    //init view
    function init() {
        //Initialization of fileupload
        initSimpleFileUpload();

        //Handler for "Start upload" button 
        $("#uploadBtn").on('click', function () {    
            util.block("#resumeUpload", true);
            if (jqXHRData) {
                jqXHRData.submit();
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
                jqXHRData = data
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
})(my.utility, my.resumeListPartial);
