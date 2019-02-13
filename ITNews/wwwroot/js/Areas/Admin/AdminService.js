let AdminService = function (actions) {
    let self = this;
    self.actions = actions;
    self.getUsers = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getUsersAction,
            cache: false
        });
    };

    self.getUser = function (id) {
        return $.ajax({
            type: 'GET',
            url: self.actions.getUserAction,
            data: { id: id },
            cache: false
        });
    };

    self.deleteUser = function (id) {
        return $.ajax({
            type: 'GET',
            url: self.actions.deleteUserAction,
            data: { id: id }
        });
    };

    self.getRoles = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getRolesAction,
            cache: false
        });
    };
}