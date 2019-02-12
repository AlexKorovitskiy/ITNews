let AdminService = function (actions) {
    let self = this;
    self.actions = actions;
    self.getUsers = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getUsersAction,
            cache: false
        });
    }
}