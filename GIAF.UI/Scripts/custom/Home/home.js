$(document).ready(function () {
    var hubProxy = $.connection.rssFeed;
    $.connection.hub.logging = true;
    $.connection.hub.start().done().fail(function (error) {
        global.popup("Error", "HubProxy doesn't start");
    });

    hubProxy.client.getConnectionId = function (_connectionId) {
        $.post(ROOT + "/Home/Read", { connectionId: _connectionId }).done(function (data) {
            global.loadGrid(data);
        }).fail(function (error) {
            global.popup("Error", error);
        });
    }

    hubProxy.client.Change = function (_url) {
        $.post(ROOT + "/Home/Read", { url: _url }).done(function (data) {
            global.loadGrid(data);
        }).fail(function (error) {
            global.popup("Error", "An error occured");
        });
    }
});


