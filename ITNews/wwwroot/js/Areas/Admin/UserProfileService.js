let UserProfileService = function (actions) {
    let self = this;
    self.actions = actions;

    self.getUser = function (id) {
        return $.ajax({
            type: 'GET',
            url: self.actions.getUserAction,
            data: { id: id },
            cache: false
        });
    };

    self.getRoles = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getRolesAction,
            cache: false
        });
    };

    self.updateUser = function (user) {
        return $.ajax({
            type: 'POST',
            url: self.actions.updateUserAction,
            data: user
        })
    }
}