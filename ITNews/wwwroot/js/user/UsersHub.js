var UserHub = function (addEntityCallBack, updateUserCallback, deleteEntityCallBack) {
    let self = this;
    self._url = domainPath + '/usershub';

    self.connection = new signalR.HubConnectionBuilder()
        .withUrl(self._url)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    self.connection.on("UpdateUser", updateUserCallback);
    self.connection.on("AddUser", addEntityCallBack);
    self.connection.on("RemoveUser", deleteEntityCallBack);
    self.connection.start();

    self.addUser = function (user) {
        self.connection.invoke("AddUser", user);
    }

    self.removeUser = function (id) {
        self.connection.invoke("RemoveUser", id);
    }
}