let MySpaceService = function (actions) {
    let self = this;
    self.actions = actions;
    self.getMyNews = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.myNewsAction,
            cache: false
        });
    };

    self.addNewsForCurrentUser = function (news) {
        return $.ajax({
            type: 'POST',
            url: self.actions.addNewsAction,
            data: { news: news },
            cache: false
        });
    };

    self.deleteNews = function (id) {
        return $.ajax({
            type: 'GET',
            url: self.actions.deleteNews,
            data: { id: id }
        });
    };

    self.getCurrentUser = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getCurrentUserAction,
            cache: false
        })
    };

    self.updateUser = function (user) {
        return $.ajax({
            type: 'POST',
            url: self.actions.updateUserAction,
            data: user
        })
    };
/*
    self.getRoles = function () {
        return $.ajax({
            type: 'GET',
            url: self.actions.getRolesAction,
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
    };*/
}