/* Scoped function outside the normal scope */

(function () {

    // Connect to the SignalR Hub on the server side
    var SignalRPerformanceHub = $.connection.signalRPerformanceHub;
    $.connection.hub.logging = true;
    $.connection.hub.start(); // asychronous

    // This is almost like an event handler that will send
    // stuff back to the Hub on the serverside
    SignalRPerformanceHub.client.showMessage = function (message) {
        // Add a message from the server to the observableArray from Knockout
        model.addMessage(message);
    };

    var Model = function () {
        var self = this;
        // Binding with KnockoutJS
        self.message = ko.observable("");
        self.messages = ko.observableArray()

    };

    Model.prototype = {
        sendMessage: function () {
            var self = this;
            SignalRPerformanceHub.server.send(self.message());
            // Clear
            self.message("");
        },
        addMessage: function () {
            var self = this;
            self.messages.push(message);
        }
    };

    // Instantiate
    var model = new Model();

    // When DOM is ready
    $(function () {
        // Bind to the view with Knockout
        ko.applyBindings(model);
    });

}());