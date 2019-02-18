var NewsHub = function (addCallBack, updateCallBack, deleteCallBack) {
    let self = this;
    self._url = domainPath + '/newshub';

    self.connection = new signalR.HubConnectionBuilder()
        .withUrl(self._url)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    self.connection.on("AddNews", addCallBack);
    self.connection.on("UpdateNews", updateCallBack);
    self.connection.on("RemoveNews", deleteCallBack);
    self.connection.start();

    self.addNews = function (news) {
        self.connection.invoke("AddNews", news);
    }

    self.removeNews = function (id) {
        self.connection.invoke("RemoveNews", id);
    }
}