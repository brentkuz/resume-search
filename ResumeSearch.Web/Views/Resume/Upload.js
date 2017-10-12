// jqXHRData needed for grabbing by data object of fileupload scope
var jqXHRData;

my.upload = (function () {

    function init() {
        //Initialization of fileupload
        initSimpleFileUpload();

        //Handler for "Start upload" button 
        $("#hl-start-upload").on('click', function () {            
            if (jqXHRData) {
                jqXHRData.submit();
            }
            return false;
        });
    }


    function initSimpleFileUpload() {
        'use strict';

        $('#fu-my-simple-upload').fileupload({
            url: '/Resume/Upload',
            dataType: 'json',
            add: function (e, data) {
                jqXHRData = data
            },
            done: function (event, data) {
                if (data.result.isUploaded) {

                }
                else {

                }
                alert(data.result.message);
            },
            fail: function (event, data) {
                if (data.files[0].error) {
                    alert(data.files[0].error);
                }
            }
        });
    }

    return {
        init: init
    }
})();
