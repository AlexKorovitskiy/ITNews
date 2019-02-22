var CommentsHub = function (addCallBack, updateCallBack, deleteCallBack) {
    let self = this;
    self._url = domainPath + '/commentshub';

    self.connection = new signalR.HubConnectionBuilder()
        .withUrl(self._url)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    self.connection.on("AddComment", addCallBack);
    self.connection.on("UpdateComment", updateCallBack);
    self.connection.on("RemoveComment", deleteCallBack);
    self.connection.start();

    self.addComment = function (comment) {
        self.connection.invoke("AddComment", comment);
    }

    self.removeComment = function (id) {
        self.connection.invoke("RemoveComment", id);
    }
}