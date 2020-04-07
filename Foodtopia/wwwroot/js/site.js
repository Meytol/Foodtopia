function InvokeViewComponent(viewComponentName, viewComponentArgument, elementId) {
    var url = "/ViewComponent/InvokeAsync?vcname=" + viewComponentName;

    if (viewComponentArgument != null) {
        url += "&arg=" + viewComponentArgument;
    }

    $.ajax({
        type: 'GET',
        url: url,
        beforeSend: function () {
            // this is where we append a loading image
            $('#' + elementId).html('<div style="display: contents;" id="ftco-loader" class="show"><svg class="circular" width="48px" height="48px"><circle class="path-bg" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke="#eeeeee" /><circle class="path" cx="24" cy="24" r="22" fill="none" stroke-width="4" stroke-miterlimit="10" stroke="#F96D00" /></svg></div>');
        },
        success: function (data) {
            // successful request; do something with the data
            $('#' + elementId).empty();
            $('#' + elementId).html(data);
            console.log(data);

        },
        error: function () {
            // failed request; give feedback to user
            $('#' + elementId).empty();
            $('#' + elementId).html('<p class="error"><strong>Oops!</strong> Try that again in a few moments.</p>');
        }
    });
}