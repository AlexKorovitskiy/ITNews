var AuthorizeService = function (actions) {
    let self = this;
    self.actions = actions;
    self.logIn = function (loginData) {
        return $.ajax({
            type: 'POST',
            url: self.actions.getToken,
            data: loginData
        })
    };

    self.registration = function (registrationModel) {
        return $.ajax({
            type: 'POST',
            url: self.actions.registration,
            data: registrationModel
        })
    }
}